using AutoMapper.Extensions.ExpressionMapping;
using Data;
using Domain.MappingProfiles;
using Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.Helper;
using Service.Services.Auth;
using Service.Services.Core;

namespace Service.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("Connection"),
                    npgsqlOptions => npgsqlOptions.MigrationsAssembly("Data"));
            }, ServiceLifetime.Scoped);

            /* Custom Logic And Database*/
            //services.AddScoped<IUserService, UserService>();
            //services.AddScoped<IApplicationService, ApplicationService>();
            //services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
            //services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            ///*Microsoft Authentication*/
            //services.AddScoped<ITokenService, TokenService>();
            //services.AddScoped<IAuthenticationService, AuthenticationService>();



            services.AddScoped(typeof(IUserService<>), typeof(UserService<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<,,>), typeof(Repository<,,>));
            services.AddScoped(typeof(IGenericService<,,>), typeof(GenericService<,,>));

            /*Microsoft Authentication*/
            services.AddScoped(typeof(ITokenService<>), typeof(TokenService<>));
            services.AddScoped(typeof(IAuthenticationService<>), typeof(AuthenticationService<>));

            /*3rd part*/
            services.AddAutoMapper(cfg => cfg.AddExpressionMapping(), typeof(DomainProfile));     

            return services;
        }
    }
}
