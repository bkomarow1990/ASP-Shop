using Shop.Application.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application.DTO.User.Admin;

namespace Shop.Application.Interfaces
{
    public interface IUserService
    {
        Task<IPagedList<UserPageUserDto>> GetUsers(GetUsersRequest getUsersRequest);
    }
}
