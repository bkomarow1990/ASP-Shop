using MediatR;
using Shop.Application.Collections;
using Shop.Application.Common.Users.Queries;
using Shop.Application.DTO.User.Admin;
using Shop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using System.Linq.Expressions;
using Shop.Application.Extensions;
using AutoMapper.QueryableExtensions;
using Shop.Application.DTO.Product;
using AutoMapper;
using Shop.Domain.Entities.Identity;

namespace Shop.Application.Common.Users.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IPagedList<UserPageUserDto>>
    {
        private readonly ShopDbContext _context;
        private readonly IMapper _mapper;

        public GetUsersHandler(ShopDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IPagedList<UserPageUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Users
                .AsNoTracking()
                
                ;
            var columnsFilter = new Dictionary<(string, bool), Expression<Func<ApplicationUser, bool>>>
            {
                [("Search", !string.IsNullOrWhiteSpace(request.GetUsersRequest.Search))] = x => String.Equals(x.Id.ToString(), request.GetUsersRequest.Search, StringComparison.CurrentCultureIgnoreCase) || x.Email.ToLower().Contains(request.GetUsersRequest.Search.ToLower()) || (x.UserName).ToLower().Contains(request.GetUsersRequest.Search),
            };
            query = query.ApplyFiltering(request.GetUsersRequest, columnsFilter);
            var queryDto = query
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .ProjectTo<UserPageUserDto>(_mapper.ConfigurationProvider);
            return await queryDto.ToPagedListAsync(request.GetUsersRequest.PageIndex, request.GetUsersRequest.PageSize,
                cancellationToken);
        }
    }
}
