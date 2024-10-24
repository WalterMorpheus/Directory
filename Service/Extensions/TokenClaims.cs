using Domain.Auth;
using Service.Collections;

namespace Service.Extensions
{
    public class TokenClaims
    {
        private readonly ServiceManager _services;
        public TokenClaims(ServiceManager services)
        {
            _services = services;
        }
        public UserClaims UserTokenClaims()
        {
            return new UserClaims 
            {
                UserAlternateId = Guid.Parse(_services.HttpContextAccessorService.HttpContext?.User?.FindFirst("UserAlternateId")?.Value),
                ApplicationAlternateId = Guid.Parse(_services.HttpContextAccessorService.HttpContext?.User?.FindFirst("ApplicationAlternateId")?.Value),
                CustomerAlternateId = Guid.Parse(_services.HttpContextAccessorService.HttpContext?.User?.FindFirst("CustomerAlternateId")?.Value)
            };
        }
    }
}
