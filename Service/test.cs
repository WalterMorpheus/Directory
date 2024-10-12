using Domain.Entity.Auth;
using Interface;
using Shared.DTOs;

namespace Service
{
    public class Test : ITest
    {
        private readonly IGenericService<User, int> _userService;

        public Test(IGenericService<User, int> userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> ConnectionAsync()
        {
            try
            {
                UserDto userDto = await _userService.GetByIdAsync<UserDto>(1);
                return userDto ?? null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
