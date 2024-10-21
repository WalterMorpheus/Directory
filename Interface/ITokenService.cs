using Shared.DTOs;

namespace Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserDto userDto);
    }
}
