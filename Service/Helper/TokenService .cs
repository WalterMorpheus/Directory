using Domain.Entity.Auth;
using Data;
using Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Shared.DTOs;

namespace Service.Helper
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public TokenService(IConfiguration config, UserManager<User> userManager, DataContext context)
        {
            _context = context;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            _userManager = userManager;
        }
        public async Task<string> CreateToken(UserDto userDto)
        {
            var user = _context.Users.FirstOrDefault(x=>x.UserName == userDto.UserName);

            var claims = new List<Claim>
            {
                new Claim("AlternateId",user.AlternateId.ToString())
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
