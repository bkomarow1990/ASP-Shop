using Shop.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.User;
using System.Net.Mail;
using System.Net;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Shop.Application.Options;
using Shop.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Application.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Shop.Domain.Entities.Identity.Token;

namespace Shop.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMediator _mediator;
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(IMediator mediator, IOptions<JwtOptions> jwtOptions, UserManager<ApplicationUser> userManager)
        {
            _mediator = mediator;
            _jwtOptions = jwtOptions;
            _userManager = userManager;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == model.Login);

            // return null if user not found
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                throw new HttpException("Invalid login or password.", HttpStatusCode.BadRequest);
            }

            // authentication successful so generate jwt and refresh tokens
            var jwtToken = await GenerateJwtToken(user);
            var refreshToken = new RefreshToken
            {
                DateCreated = DateTime.UtcNow,
                Token = await GenerateRefreshToken(),
                Expires = DateTime.Now.AddHours(72),
                Revoked = null,
                ReplacedByToken = null,
                UserId = user.Id
            };
            // save refresh token
            user.RefreshTokens.Add(refreshToken);
            await _userManager.UpdateAsync(user);
            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public async Task<AuthenticateResponse> RefreshToken(string token)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == token));

            // return null if no user found with token
            if (user == null) return null;

            var refreshToken = user.RefreshTokens.First(x => x.Token == token);

            // return null if token is no longer active#
            if (!refreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = await GenerateRefreshToken();
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken;
            RefreshToken refreshTokenEntity = new RefreshToken()
            {
                DateCreated = DateTime.UtcNow,
                DateEdited = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(72),
                UserId = user.Id,
                Token = newRefreshToken,
            };
            user.RefreshTokens.Add(refreshTokenEntity);
            await _userManager.UpdateAsync(user);

            // generate new jwt
            var jwtToken = await GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtToken, newRefreshToken);
        }

        public async Task<bool> RevokeToken(string token)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == token));

            // return false if no user found with token
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.First(x => x.Token == token);

            // return false if token is not active
            if (!refreshToken.IsActive) return false;

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return true;
        }

        public async Task Register(RegisterUserDTO registerUserDTO)
        {
            if (registerUserDTO == null)
            {
                throw new HttpException("Incorrect data for registration", HttpStatusCode.BadRequest);
            }

            var user = new ApplicationUser
            {
                Email = registerUserDTO.Email,
                UserName = registerUserDTO.Email
            };
            var result = await _userManager.CreateAsync(user, registerUserDTO.Password);
            if (!result.Succeeded)
            {
                StringBuilder messageBuilder = new StringBuilder();
                foreach (var error in result.Errors)
                {
                    messageBuilder.AppendLine(error.Description);
                }

                throw new HttpException(messageBuilder.ToString(), HttpStatusCode.BadRequest);
            }
        }
        // helper methods

        private async Task<string> GenerateJwtToken(ApplicationUser user)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Secret));
            var roles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),

            };
            foreach (var role in roles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }
            //new Claim(ClaimTypes.Role, )
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.ValidIssuer,
                audience: _jwtOptions.Value.ValidAudience,
                expires: DateTime.Now.AddMinutes(_jwtOptions.Value.TokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return await Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }

        private async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return await Task.FromResult(Convert.ToBase64String(randomNumber));
            //using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            //{
            //    var randomBytes = new byte[64];
            //    rngCryptoServiceProvider.GetBytes(randomBytes);
            //    return new RefreshToken
            //    {
            //        Token = Convert.ToBase64String(randomBytes),
            //        Expires = DateTime.UtcNow.AddDays(7),
            //        DateCreated = DateTime.UtcNow,
            //    };
            //}
        }
    }
}
