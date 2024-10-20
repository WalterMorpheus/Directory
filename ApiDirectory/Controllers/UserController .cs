using Domain.DTOs;
using Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiDirectory.Controllers
{
    public class UserController : BaseApiController, IUserEndpointService<UserDto>
    {
        private readonly IUserService<UserDto> _userService;
        public UserController(IUserService<UserDto> userService)
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
