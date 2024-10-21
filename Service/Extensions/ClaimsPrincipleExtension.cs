using System.Security.Claims;

namespace Service.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static string GetUserToken(this ClaimsPrincipal user)
        {
            return user.FindFirst("AlternateId")?.Value;
        }
    }
}
