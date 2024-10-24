using Domain.DTOs.External;

namespace Interface
{
    public interface IAuthenticationService
    {
        Task<bool> AddAsync(UserDto dto);
    }
}
