using Domain.Entity.Auth;
using Data;
using Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Domain.DTOs.External;
using Domain.DTOs.Interanal;
using Service.Services.Core;
using Service.Services.Auth;

namespace Service.Helper
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        private readonly GenericService<UserDto> _userService;
        private readonly GenericService<IntUserDto> _intUserService;
        private readonly GenericService<CustomerDto> _customerDtoService;
        private readonly GenericService<IntCustomerDto> _intCustomerService;
        private readonly GenericService<ApplicationDto> _applicationService;
        private readonly GenericService<IntApplicationDto> _intApplicationDtoService;
        private readonly GenericService<CustomerApplicationDto> _customerApplicationService;
        private readonly GenericService<UserCustomerDto> _userCustomerService;
        private readonly GenericService<BusinessTypeDto> _businessTypeService;


        public TokenService(IConfiguration config, UserManager<User> userManager, DataContext context,GenericService<UserDto> userService,
            GenericService<IntUserDto> intUserService,
            GenericService<CustomerDto> customerDtoService,
            GenericService<IntCustomerDto> intCustomerService,
            GenericService<ApplicationDto> applicationService,
            GenericService<IntApplicationDto> intApplicationDtoService,
            GenericService<CustomerApplicationDto> customerApplicationService,
            GenericService<UserCustomerDto> userCustomerService,
            GenericService<BusinessTypeDto> businessTypeService)
        {
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;


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
        public async Task<string> CreateToken(UserDto dto)
        {
            var user = _context.Users.FirstOrDefault(x=>x.UserName == dto.UserName);
            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new InvalidOperationException("username or password is incorrect");
            }

            UserCustomerDto userCustomerDto = await _userCustomerService.GetByReferenceAsync(x => x.UserId == user.Id);
            CustomerApplicationDto customerApplicationDto = await _customerApplicationService.GetByReferenceAsync(x => x.CustomerId == userCustomerDto.CustomerId);
            IntCustomerDto intCustomerDto = await _intCustomerService.GetByReferenceAsync(x => x.Id == customerApplicationDto.CustomerId);
            IntApplicationDto intApplicationDto = await _intApplicationDtoService.GetByReferenceAsync(x => x.Id == customerApplicationDto.ApplicationId);

            var claims = new List<Claim>
            {
                new Claim("UserAlternateId",user.AlternateId.ToString()),
                new Claim("ApplicationAlternateId",intApplicationDto.AlternateId.ToString()),
                new Claim("CustomerAlternateId",intCustomerDto.AlternateId.ToString())
            };

            claims.AddRange((await _userManager.GetRolesAsync(user)).Select(x => new Claim(ClaimTypes.Role, x)));
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
