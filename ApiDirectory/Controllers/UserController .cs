using Domain.DTOs.External;
using Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiDirectory.Controllers
{
    public class UserController : BaseApiController, IUserEndpointService<UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("applications")]
        public async Task<List<ApplicationDto>> ApplicationsAsync()
        {
            return  await _userService.Applications() ;
        }

        [HttpPost("login")]
        public async Task<ActionResult<object>> LoginAsync(UserDto dto) 
        {
            return new { token = await _userService.Login(dto) }; 
        }
        [HttpPost("register")]
        public async Task<ActionResult<object>> RegisterAsync(UserDto dto)
        {
            return new { token = await _userService.Register(dto) };
        }
    }
}
