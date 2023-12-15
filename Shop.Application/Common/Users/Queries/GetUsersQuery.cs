using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Collections;
using Shop.Application.DTO.User.Admin;

namespace Shop.Application.Common.Users.Queries
{
    public record GetUsersQuery(GetUsersRequest GetUsersRequest) : IRequest<IPagedList<UserPageUserDto>>;
}
