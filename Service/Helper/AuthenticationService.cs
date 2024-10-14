using AutoMapper;
using Domain.Entity.Auth;
using Interface;
using Microsoft.AspNetCore.Identity;
using Shared.DTOs;

namespace Service.Helper
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthenticationService(UserManager<User> userManager,IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddAsync(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.UserName.ToLower();
            user.Email = dto.Email.ToLower();

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded) throw new InvalidOperationException("unable to add user to authentication");

            var roleResult = await _userManager.AddToRoleAsync(user, "User");
            if (!roleResult.Succeeded) throw new InvalidOperationException("unable to add user role to authentication");

            _unitOfWork.Equals(roleResult);
        }
    }
}
