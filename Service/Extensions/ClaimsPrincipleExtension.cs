using Domain.Auth;
using System.Security.Claims;

namespace Service.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static UserClaims GetUserToken(this ClaimsPrincipal claims)
        {
            return new UserClaims 
            {
                UserAlternateId = Guid.Parse( claims.FindFirst("UserAlternateId")?.Value),
                ApplicationAlternateId = Guid.Parse(claims.FindFirst("ApplicationAlternateId")?.Value),
                CustomerAlternateId = Guid.Parse(claims.FindFirst("CustomerAlternateId")?.Value)
            };
        }
    }
}
