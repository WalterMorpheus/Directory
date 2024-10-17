using Interface;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace ApiDirectory.Controllers
{
    public class UserController : BaseApiController, IUserEndpointService<UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<object>> LoginAsync(UserDto dto) 
        {
            return new { token = await _userService.login(dto) }; 
        }
        [HttpPost("register")]
        public async Task<ActionResult<object>> RegisterAsync(UserDto dto)
        {
            return new { token = await _userService.Register(dto) };
        }
    }
}
