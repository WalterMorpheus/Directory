using Domain.Entity.Auth;
using Interface;

namespace Service
{
    public class Test : ITest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericService<User, int> _userService;

        public Test(IUnitOfWork unitOfWork, IGenericService<User, int> userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;

        }
        public async Task<dynamic> ConnectionAsync()
        {           
            try
            {
                return await _userService.GetByIdAsync(1);
            }
            catch (Exception)
            {
                return new {};
            }
        }
    }
}
