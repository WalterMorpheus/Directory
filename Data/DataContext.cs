using Data.Entity.Auth;
using Data.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Data
{
    public class DataContext : IdentityDbContext<User, Role, int,
     UserClaim, UserRole,UserLogin,
     IdentityRoleClaim, IdentityUserToken>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /*Injects all the EntityType Configurations*/
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            /*Gets all the data that needs to be inesrted in the database when entity migration are run*/
            DataSeeder.Seed(builder);
        }
    }
}