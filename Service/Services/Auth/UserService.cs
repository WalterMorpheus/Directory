using Domain.DTOs.External;
using Interface;
using Service.Collections;
using Service.Services.Core;

namespace Service.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly GenericService<CustomerApplicationDto> _customerApplicationService;
        private readonly ITokenService _tokenService;
        private readonly ServiceManager _serviceManager;

        public UserService(ITokenService tokenService,GenericService<CustomerApplicationDto> customerApplicationService, ServiceManager serviceManager)
        {
            _tokenService = tokenService;
            _serviceManager = serviceManager;
            _customerApplicationService = customerApplicationService;
        }

        public async Task<string> Login(UserDto dto)
        {
            return await _tokenService.CreateToken(dto);
        }

        public async Task<string> Register(UserDto dto)
        {
            await _serviceManager.AuthenticationService.AddAsync(dto);
            await _customerApplicationService.Add(new CustomerApplicationDto { });

            return await _tokenService.CreateToken(dto);
        }
    }

}
