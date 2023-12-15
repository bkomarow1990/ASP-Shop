using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Shop.Application.Collections;
using Shop.Application.Common.Users.Queries;
using Shop.Application.DTO.User.Admin;
using Shop.Application.Interfaces;

namespace Shop.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMediator _mediator;

        public UserService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IPagedList<UserPageUserDto>> GetUsers(GetUsersRequest getUsersRequest)
        {
            return await _mediator.Send(new GetUsersQuery(getUsersRequest));
        }
    }
}
