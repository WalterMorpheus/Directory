using Shared.DTOs;

namespace Interface
{
    public interface IUserService
    {
        Task<string> login(UserDto user);
    }
}
