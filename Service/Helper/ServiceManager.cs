using Domain.DTOs.External;
using Domain.DTOs.Interanal;
using Domain.Entity.Auth;
using Domain.Entity.Core;
using Interface;
using Microsoft.AspNetCore.Http;

namespace Service.Helper
{
    public class ServiceManager
    {
        public IGenericService<UserDto, User, int> UserService { get; }
        public IGenericService<IntUserDto, User, int> IntUserService { get; }
        public IGenericService<CustomerDto, Customer, int> CustomerDtoService { get; }
        public IGenericService<IntCustomerDto, Customer, int> IntCustomerService { get; }
        public IGenericService<ApplicationDto, Application, int> ApplicationService { get; }
        public IGenericService<IntApplicationDto, Application, int> IntApplicationDtoService { get; }
        public IGenericService<CustomerApplicationDto, CustomerApplication, int> CustomerApplicationService { get; }
        public IGenericService<UserCustomerDto, UserCustomer, int> UserCustomerService { get; }
        public IHttpContextAccessor HttpContextAccessorService { get; }
        public IAuthenticationService AuthenticationService { get; }

        public ServiceManager(
            IGenericService<UserDto, User, int> userService,
            IGenericService<IntUserDto, User, int> intUserService,
            IGenericService<CustomerDto, Customer, int> customerDtoService,
            IGenericService<IntCustomerDto, Customer, int> intCustomerService,
            IGenericService<ApplicationDto, Application, int> applicationService,
            IGenericService<IntApplicationDto, Application, int> intApplicationDtoService,
            IGenericService<CustomerApplicationDto, CustomerApplication, int> customerApplicationService,
            IGenericService<UserCustomerDto, UserCustomer, int> userCustomerService,

            IHttpContextAccessor httpContextAccessorService,
            IAuthenticationService authenticationService)
        {
            UserService = userService;
            IntUserService = intUserService;
            CustomerDtoService = customerDtoService;
            IntCustomerService = intCustomerService;
            ApplicationService = applicationService;
            IntApplicationDtoService = intApplicationDtoService;
            CustomerApplicationService = customerApplicationService;
            UserCustomerService = userCustomerService;
            HttpContextAccessorService = httpContextAccessorService;    
            AuthenticationService = authenticationService;
        }
    }

}
