using Domain.Entity.Auth;
using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {

            builder.Entity<Role>().HasData(
              new Role
              {
                  Id = 1,
                  Name = "Admin",
                  NormalizedName = "ADMIN"
              },
              new Role
              {
                  Id = 2,
                  Name = "User",
                  NormalizedName = "USER",
              }
            );

            builder.Entity<Application>().HasData(
               new Application
               {
                   Id = 1,
                   Name = "Mobile"
               },
               new Application
               {
                   Id = 2,
                   Name = "Usage"
               },
               new Application
               {
                   Id = 3,
                   Name = "On-bill"
               }
           );

        }
    }
}
