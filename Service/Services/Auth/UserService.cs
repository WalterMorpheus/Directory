using Domain.DTOs.External;
using Interface;
using Service.Collections;
using Service.Services.Core;

namespace Service.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly GenericService<ApplicationDto> _applicationDtoService;
        private readonly ITokenService _tokenService;
        private readonly ServiceManager _serviceManager;

        public UserService(ITokenService tokenService, GenericService<ApplicationDto> applicationDtoService, ServiceManager serviceManager)
        {
            _tokenService = tokenService;
            _serviceManager = serviceManager;
            _applicationDtoService = applicationDtoService;
        }

        public async Task<List<ApplicationDto>> Applications()
        {
            return (List<ApplicationDto>)await _applicationDtoService.List();
        }

        public async Task<string> Login(UserDto dto)
        {
            return await _tokenService.CreateToken(dto);
        }

        public async Task<string> Register(UserDto dto)
        {
            if (!await _serviceManager.AuthenticationService.AddAsync(dto))
                return string.Empty;

            return await _tokenService.CreateToken(dto);
        }

    }
}
