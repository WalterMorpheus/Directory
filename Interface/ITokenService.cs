using Domain.DTOs.External;

namespace Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserDto userDto);
    }
}
