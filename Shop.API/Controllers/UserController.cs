using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Shop.Application.Collections;
using Shop.Application.DTO.User.Admin;
using Shop.Application.Interfaces;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("get-users")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<IPagedList<UserPageUserDto>>> GetUsers([FromQuery] GetUsersRequest getUsersRequest)
        {
            return Ok(await _userService.GetUsers(getUsersRequest));
        }
    }
}
