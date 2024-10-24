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
using Service.Services.Core;

namespace Service.Helper
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        private readonly GenericService<UserDto> _userService;

        public TokenService(IConfiguration config, UserManager<User> userManager, DataContext context,GenericService<UserDto> userService)
        {
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
            _userService = userService;
        }
        public async Task<string> CreateToken(UserDto dto)
        {
            var user = _context.Users.FirstOrDefault(x=>x.UserName == dto.UserName);
            if (!await _userManager.CheckPasswordAsync(user, dto.Password))
            {
                throw new InvalidOperationException("username or password is incorrect");
            }

            UserDto userDto = await _userService.GetByReferenceAsync(x => x.AlternateId == user.AlternateId);

            var claims = new List<Claim>
            {
                new Claim("UserAlternateId",userDto.AlternateId.ToString()),
                new Claim("CustomerAlternateId",userDto.UserCustomers.FirstOrDefault().Customer.AlternateId.ToString())
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
