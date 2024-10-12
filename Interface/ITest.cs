using Shared.DTOs;

namespace Interface
{
    public interface ITest
    {
        Task<UserDto> ConnectionAsync();
    }
}
