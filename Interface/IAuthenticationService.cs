using Domain.DTOs.External;

namespace Interface
{
    public interface IAuthenticationService
    {
        Task<int> AddAsync(UserDto dto);
    }
}
