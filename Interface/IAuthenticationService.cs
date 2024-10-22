using Domain.DTOs.External;

namespace Interface
{
    public interface IAuthenticationService
    {
        Task AddAsync(UserDto dto);
    }
}
