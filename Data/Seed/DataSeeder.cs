using Data.Entity.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Data.Seed
{
    public static class DataSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            Role adminRole = new Role
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                AlternateId = Guid.NewGuid()
            };

            Role userRole = new Role
            {
                Id = 2,
                Name = "User",
                NormalizedName = "USER",
                AlternateId = Guid.NewGuid()
            };
            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User adminUser = new User
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = string.Empty,
                AlternateId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow
            };

            adminUser.PasswordHash = hasher.HashPassword(adminUser, "AdminPassword123!");

            builder.Entity<Role>().HasData(adminRole, userRole);
            builder.Entity<User>().HasData(adminUser);

            builder.Entity<UserRole>().HasData(new UserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id,
                AlternateId = Guid.NewGuid(),
                CreatedDate = DateTime.UtcNow,
                CreatedBy = "migration_seeding"
            });
        }
    }
}
