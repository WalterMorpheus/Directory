using Interface;
using Microsoft.AspNetCore.Http;

namespace Service.Collections
{
    public class ServiceManager
    {

        public IHttpContextAccessor HttpContextAccessorService { get; }
        public IAuthenticationService AuthenticationService { get; }

        public ServiceManager(

            IHttpContextAccessor httpContextAccessorService,
            IAuthenticationService authenticationService)
        {
            HttpContextAccessorService = httpContextAccessorService;
            AuthenticationService = authenticationService;
        }
    }

}
