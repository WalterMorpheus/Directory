using Domain.Entity.Auth;
using Interface;
using Shared.DTOs;

namespace Service
{
    public class Test : ITest
    {
        private readonly IGenericService<UserDto,User, int> _userService;

        public Test(IGenericService<UserDto,User, int> userService)
        {
            _userService = userService;
        }

        public async Task<UserDto> ConnectionAsync()
        {
            //UserDto userDto = await _userService.GetByIdAsync<UserDto>(1);
            return  null;
        }
    }
}
