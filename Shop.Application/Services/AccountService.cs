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
            var jwtToken = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            // save refresh token
            user.RefreshTokens.Add(refreshToken);
            //await _mediator.Send(new UpdateUserCommand(user));
            return new AuthenticateResponse(user, jwtToken, refreshToken.Token);
        }

        public Task<AuthenticateResponse> RefreshToken(string token)
        {
            var user = await _mediator.Send(new GetUserByJwtTokenQuery(token));//_context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == token));

            // return null if no user found with token
            if (user == null) return null;

            var refreshToken = user.RefreshTokens.First(x => x.Token == token);

            // return null if token is no longer active#
            if (!refreshToken.IsActive) return null;

            // replace old refresh token with a new one and save
            var newRefreshToken = GenerateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(newRefreshToken);
            await _mediator.Send(new UpdateUserCommand(user));

            // generate new jwt
            var jwtToken = GenerateJwtToken(user);
            return new AuthenticateResponse(user, jwtToken, newRefreshToken.Token);
        }

        public Task Register(RegisterUserDTO registerUserDTO)
        {
            throw new NotImplementedException();
        }
        // helper methods

        private string GenerateJwtToken(ApplicationUser user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Value.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Value.Issuer,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(_jwtOptions.Value.LifeTime),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private RefreshToken GenerateRefreshToken()
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(7),
                    DateCreated = DateTime.UtcNow,
                };
            }
        }
    }
}
