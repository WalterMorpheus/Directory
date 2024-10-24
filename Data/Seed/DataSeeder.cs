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

/*
            builder.Entity<BusinessAreaType>().HasData(
                new BusinessAreaType
                {
                    Id = 1,
                    Name = "Location",
                    AlternateId = Guid.NewGuid()
                },
                new BusinessAreaType
                {
                    Id = 2,
                    Name = "Department",
                    AlternateId = Guid.NewGuid()
                },
                new BusinessAreaType
                {
                    Id = 3,
                    Name = "Cost Centre",
                    AlternateId = Guid.NewGuid()
                }
            );

            builder.Entity<BusinessArea>().HasData(
                new BusinessArea
                {
                    Id = 1,
                    Name = "Johannesburg",
                    AlternateId = Guid.NewGuid(),
                    BusinessAreaTypeId = 1 
                },
                new BusinessArea
                {
                    Id = 2,
                    Name = "Durban",
                    AlternateId = Guid.NewGuid(),
                    BusinessAreaTypeId = 1
                },
                new BusinessArea
                {
                    Id = 3,
                    Name = "IT",
                    AlternateId = Guid.NewGuid(),
                    BusinessAreaTypeId = 2
                },
                new BusinessArea
                {
                    Id = 4,
                    Name = "HR",
                    AlternateId = Guid.NewGuid(),
                    BusinessAreaTypeId = 2
                },
                new BusinessArea
                {
                    Id = 5,
                    Name = "Permanent",
                    AlternateId = Guid.NewGuid(),
                    BusinessAreaTypeId = 3
                }
            );

            builder.Entity<BusinessAreaTypeRelationship>().HasData(
                new BusinessAreaTypeRelationship
                {
                    ParentTypeId = 1,
                    ChildTypeId = 2 
                },
                new BusinessAreaTypeRelationship
                {
                    ParentTypeId = 2,
                    ChildTypeId = 3 
                }
            );


            builder.Entity<BusinessAreaRelationship>().HasData(
                new BusinessAreaRelationship
                {
                    ParentBusinessAreaId = 1,
                    ChildBusinessAreaId = 3 
                },
                new BusinessAreaRelationship
                {
                    ParentBusinessAreaId = 1,
                    ChildBusinessAreaId = 4
                },
                new BusinessAreaRelationship
                {
                    ParentBusinessAreaId = 3,
                    ChildBusinessAreaId = 5
                },
                new BusinessAreaRelationship
                {
                    ParentBusinessAreaId = 4,
                    ChildBusinessAreaId = 5
                }
            );
*/
        }
    }
}
