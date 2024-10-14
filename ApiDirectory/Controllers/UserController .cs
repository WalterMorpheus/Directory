using Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace ApiDirectory.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("login")]
        public async Task<ActionResult<object>> Login(UserDto dto) 
        {
            return new { token = await _userService.login(dto) }; 
        }
        [HttpPut("register")]
        public async Task<ActionResult<object>> Register(UserDto dto)
        {
            return new { token = await _userService.Register(dto) };
        }
    }
}
