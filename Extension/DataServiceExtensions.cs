using Data;
using Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions
{
    public  class DataServiceExtensions : IServiceExtensions
    {
        public IServiceCollection AddServices(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseNpgsql(config.GetConnectionString("Connection"));
            });

            return services;
        }
    }
}
