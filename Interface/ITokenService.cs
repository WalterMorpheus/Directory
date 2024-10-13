using Domain.Entity.Auth;

namespace Interface
{
    public interface ITokenService
    {
        Task<string> CreateToken(User user);
    }
}
