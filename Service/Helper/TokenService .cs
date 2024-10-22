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

namespace Service.Helper
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;
        private readonly ServiceManager _services;

        public TokenService(IConfiguration config, UserManager<User> userManager, DataContext context, ServiceManager services)
        {
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
            _services = services;   
        }
        public async Task<string> CreateToken(UserDto dto)
        {
            var user = _context.Users.FirstOrDefault(x=>x.UserName == dto.UserName);
            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new InvalidOperationException("username or password is incorrect");
            }

            UserCustomerDto userCustomerDto = await _services.UserCustomerService.GetByReferenceAsync(x => x.UserId == user.Id);
            CustomerApplicationDto customerApplicationDto = await _services.CustomerApplicationService.GetByReferenceAsync(x => x.CustomerId == userCustomerDto.CustomerId);
            IntCustomerDto intCustomerDto = await _services.IntCustomerService.GetByReferenceAsync(x => x.Id == customerApplicationDto.CustomerId);
            IntApplicationDto intApplicationDto = await _services.IntApplicationDtoService.GetByReferenceAsync(x => x.Id == customerApplicationDto.ApplicationId);

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
