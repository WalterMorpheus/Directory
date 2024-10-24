using AutoMapper;
using Data;
using Domain.DTOs.External;
using Domain.Entity.Auth;
using Interface;
using Microsoft.AspNetCore.Identity;
using Service.Services.Core;

namespace Service.Helper
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public AuthenticationService(UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork, DataContext context)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public async Task<int> AddAsync(UserDto dto)
        {
            if (_context.Users.FirstOrDefault(x => x.UserName == dto.UserName) != null)
                throw new InvalidOperationException("A user with the same credentials already exists");

            var user = _mapper.Map<User>(dto);
            user.UserName = dto.UserName.ToLower();
            user.Email = dto.Email.ToLower();

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) 
                throw new InvalidOperationException("unable to add user to authentication");

            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded) 
                throw new InvalidOperationException("unable to add user role to authentication");

            _unitOfWork.Equals(roleResult);

            return _context.Users.FirstOrDefault(x => x.UserName == dto.UserName).UserCustomers.FirstOrDefault().Customer.Id;
        }
    }
}
