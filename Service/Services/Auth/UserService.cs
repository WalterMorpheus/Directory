using Domain.DTOs.External;
using Domain.DTOs.Interanal;
using Domain.Entity.Auth;
using Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Collections;
using Service.Services.Core;
using System.Text;

namespace Service.Services.Auth
{
    public class UserService : IUserService
    {


        private readonly GenericService<UserDto> _userService;
        private readonly GenericService<IntUserDto> _intUserService;
        private readonly GenericService<CustomerDto> _customerDtoService;
        private readonly GenericService<IntCustomerDto> _intCustomerService;
        private readonly GenericService<ApplicationDto> _applicationService;
        private readonly GenericService<IntApplicationDto> _intApplicationDtoService;
        private readonly GenericService<CustomerApplicationDto> _customerApplicationService;
        private readonly GenericService<UserCustomerDto> _userCustomerService;
        private readonly GenericService<BusinessTypeDto> _businessTypeService;

        private readonly ServiceManager _services;
        private readonly ITokenService _tokenService;

        public UserService(ITokenService tokenService,GenericService<UserDto> userService,
            GenericService<IntUserDto> intUserService,
            GenericService<CustomerDto> customerDtoService,
            GenericService<IntCustomerDto> intCustomerService,
            GenericService<ApplicationDto> applicationService,
            GenericService<IntApplicationDto> intApplicationDtoService,
            GenericService<CustomerApplicationDto> customerApplicationService,
            GenericService<UserCustomerDto> userCustomerService,
            GenericService<BusinessTypeDto> businessTypeService)
        {
            _tokenService = tokenService;

            _userService = userService;
            _intUserService = intUserService;
            _customerDtoService = customerDtoService;
            _intCustomerService = intCustomerService;
            _applicationService = applicationService;
            _intApplicationDtoService = intApplicationDtoService;
            _customerApplicationService = customerApplicationService;
            _userCustomerService = userCustomerService;
            _businessTypeService = businessTypeService;
        }

        public async Task<string> Login(UserDto dto)
        {
            return await _tokenService.CreateToken(dto);
        }

        public async Task<string> Register(UserDto dto)
        {
            if (await _userService.GetByReferenceAsync(u => u.UserName == dto.UserName) != null)
                throw new InvalidOperationException("A user with the same credentials already exists");

            if (await _customerDtoService.GetByReferenceAsync(u => u.Name == dto.CustomerName) != null)
                throw new InvalidOperationException("A customer with the same name already exists");

            if (await _applicationService.GetByReferenceAsync(u => u.AlternateId == dto.ApplicationAlternateId) == null)
                throw new InvalidOperationException("Application does not exist");

            await _services.AuthenticationService.AddAsync(dto);
            await _customerDtoService.Add(new CustomerDto { Name = dto.CustomerName });

            IntApplicationDto intApplicationDto = await _intApplicationDtoService.GetByReferenceAsync(u => u.AlternateId == dto.ApplicationAlternateId);
            IntCustomerDto intCustomerDto = await _intCustomerService.GetByReferenceAsync(u => u.Name == dto.CustomerName);
            IntUserDto intUserDto = await _intUserService.GetByReferenceAsync(u => u.UserName == dto.UserName);

            await _customerApplicationService.Add(new CustomerApplicationDto
            {
                ApplicationId = intApplicationDto.Id,
                CustomerId = intCustomerDto.Id
            });

            await _userCustomerService.Add(new UserCustomerDto
            {
                UserId = intUserDto.Id,
                CustomerId = intCustomerDto.Id
            });

            return await _tokenService.CreateToken(dto);
        }
    }

}
