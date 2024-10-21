using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class UserCustomerConfiguration : IEntityTypeConfiguration<UserCustomer>
    {
        public void Configure(EntityTypeBuilder<UserCustomer> builder)
        {
            builder.HasOne(x => x.User)
                   .WithMany(x => x.UserCustomers)
                   .HasForeignKey(x => x.UserId)
                    .IsRequired();

            builder.HasOne(x => x.Customer)
                   .WithMany(x => x.UserCustomers)
                   .HasForeignKey(x => x.CustomerId)
                   .IsRequired();
        }
    }
}
