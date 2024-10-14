using Shared.DTOs;

namespace Interface
{
    public interface IAuthenticationService
    {
        Task AddAsync(UserDto dto);
    }
}
