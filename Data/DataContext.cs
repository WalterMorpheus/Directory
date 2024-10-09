using Data.Entity.Auth;
using Data.Entity.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class DataContext : IdentityDbContext<User, Role, int,
     UserClaim, UserRole,UserLogin,
     IdentityRoleClaim, IdentityUserToken>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<CustomerApplication> CustomerApplications { get; set; }
        public DbSet<UserCustomer> UserCustomers { get; set; }
        public DbSet<BusinessArea> BusinessAreas { get; set; }
        public DbSet<BusinessAreaType> BusinessAreaTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>(entity =>
            {
                entity.ToTable(name: "asp_net_users");
            });

            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "asp_net_roles");
            });

            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable("asp_net_user_roles");
            });

            builder.Entity<UserClaim>(entity =>
            {
                entity.ToTable("asp_net_user_claims");
            });

            builder.Entity<UserLogin>(entity =>
            {
                entity.ToTable("asp_net_user_logins");  
            });

            builder.Entity<IdentityRoleClaim>(entity =>
            {
                entity.ToTable("asp_net_role_claims");
            });

            builder.Entity<IdentityUserToken>(entity =>
            {
                entity.ToTable("asp_net_user_tokens");
            });

            //builder.Entity<User>()
            //    .HasMany(u => u.UserRoles)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(ur => ur.UserId)
            //    .IsRequired();

            //builder.Entity<Role>()
            //    .HasMany(r => r.UserRoles)
            //    .WithOne(r => r.Role)
            //    .HasForeignKey(r => r.RoleId)
            //    .IsRequired();

            //builder.Entity<CustomerApplication>(entity =>
            //{

            //    entity.HasKey(e => e.Id);

            //    entity.HasOne(e => e.Customer)
            //          .WithMany() 
            //          .HasForeignKey(e => e.CustomerId)
            //          .OnDelete(DeleteBehavior.Restrict);

            //    entity.HasOne(e => e.Application)
            //          .WithMany() 
            //          .HasForeignKey(e => e.ApplicationId)
            //          .OnDelete(DeleteBehavior.Restrict); 

            //    entity.HasIndex(e => new { e.CustomerId, e.ApplicationId })
            //          .IsUnique();
            //});

            //builder.Entity<User>()
            //    .HasMany(x => x.UserCustomers)
            //    .WithOne(x => x.User)
            //    .HasForeignKey(ur => ur.UserId)
            //    .IsRequired();

            //builder.Entity<Customer>()
            //    .HasMany(x => x.UserCustomers)
            //    .WithOne(x => x.Customer)
            //    .HasForeignKey(x => x.CustomerId)
            //    .IsRequired();


            //builder.Entity<BusinessAreaTypeRelationship>(entity =>
            //{
            //    entity.HasKey(e => e.Id);

            //    entity.HasOne(e => e.BusinessAreaTypeParent)
            //          .WithMany() 
            //          .HasForeignKey(e => e.BusinessAreaTypeParentId)
            //          .OnDelete(DeleteBehavior.Restrict);

            //    entity.HasOne(e => e.BusinessAreaTypeChild)
            //          .WithMany() 
            //          .HasForeignKey(e => e.BusinessAreaTypeChildId)
            //          .OnDelete(DeleteBehavior.Restrict);

            //    entity.HasIndex(e => new { e.BusinessAreaTypeParentId, e.BusinessAreaTypeChildId })
            //          .IsUnique()
            //          .HasDatabaseName("UC_BusinessAreaTypeRelationship");
            //});


        }
    }
}

