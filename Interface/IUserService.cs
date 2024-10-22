using Domain.DTOs.External;

namespace Interface
{
    public interface IUserService
    {
        Task<string> Login(UserDto user);
        Task<string> Register(UserDto user);
        
    }
}
