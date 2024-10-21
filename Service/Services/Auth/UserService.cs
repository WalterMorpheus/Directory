using Domain.Entity.Auth;
using Interface;
using Shared.DTOs;

namespace Service.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly IGenericService<UserDto,User, int> _userService;
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationService _authenticationService;
        public UserService(IGenericService<UserDto,User, int> userService, ITokenService tokenService, IAuthenticationService authenticationService)
        {
            _userService = userService;
            _tokenService = tokenService;
            _authenticationService = authenticationService;
        }
        public async Task<string> login(UserDto dto)
        {
            return await _tokenService.CreateToken(dto);
        }
        public async Task<string> Register(UserDto dto)
        {
            if ( await _userService.GetByReferenceAsync(u => u.UserName == dto.UserName) != null)
                throw new InvalidOperationException("A user with the same credentials already exists");

            await _authenticationService.AddAsync(dto);
            return await _tokenService.CreateToken(dto);
        }
    }
}
