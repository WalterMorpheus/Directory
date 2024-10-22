using Domain.DTOs.External;
using Domain.DTOs.Interanal;
using Interface;
using Service.Helper;

namespace Service.Services.Auth
{
    public class UserService : IUserService
    {
        private readonly ServiceManager _services;
        private readonly ITokenService _tokenService;

        public UserService(ServiceManager services,ITokenService tokenService)
        {
            _services = services;
            _tokenService = tokenService;
        }

        public async Task<string> Login(UserDto dto)
        {
            return await _tokenService.CreateToken(dto);
        }

        public async Task<string> Register(UserDto dto)
        {
            if (await _services.UserService.GetByReferenceAsync(u => u.UserName == dto.UserName) != null)
                throw new InvalidOperationException("A user with the same credentials already exists");

            if (await _services.CustomerDtoService.GetByReferenceAsync(u => u.Name == dto.CustomerName) != null)
                throw new InvalidOperationException("A customer with the same name already exists");

            if (await _services.ApplicationService.GetByReferenceAsync(u => u.AlternateId == dto.ApplicationAlternateId) == null)
                throw new InvalidOperationException("Application does not exist");

            await _services.AuthenticationService.AddAsync(dto);
            await _services.CustomerDtoService.AddAsync(new CustomerDto { Name = dto.CustomerName });

            IntApplicationDto intApplicationDto = await _services.IntApplicationDtoService.GetByReferenceAsync(u => u.AlternateId == dto.ApplicationAlternateId);
            IntCustomerDto intCustomerDto = await _services.IntCustomerService.GetByReferenceAsync(u => u.Name == dto.CustomerName);
            IntUserDto intUserDto = await _services.IntUserService.GetByReferenceAsync(u => u.UserName == dto.UserName);

            await _services.CustomerApplicationService.AddAsync(new CustomerApplicationDto
            {
                ApplicationId = intApplicationDto.Id,
                CustomerId = intCustomerDto.Id
            });

            await _services.UserCustomerService.AddAsync(new UserCustomerDto
            {
                UserId = intUserDto.Id,
                CustomerId = intCustomerDto.Id
            });

            return await _tokenService.CreateToken(dto);
        }
    }

}
