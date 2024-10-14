using Domain.Entity.Auth;
using Interface;
using Shared.DTOs;

namespace Service.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IGenericService<UserDto,User, int> _userService;
        private readonly ITokenService _tokenService;
        public UserService(IGenericService<UserDto,User, int> userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;   
        }
        public async Task<string> login(UserDto userDto)
        {
            var user = await _userService.GetByReferenceAsync(u => u.UserName == userDto.UserName);
            if (user == null) return string.Empty;

            return await _tokenService.CreateToken(user);
        }
    }
}
