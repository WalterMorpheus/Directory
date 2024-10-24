using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class UserCustomerConfiguration : IEntityTypeConfiguration<UserCustomerApplication>
    {
        public void Configure(EntityTypeBuilder<UserCustomerApplication> builder)
        {

            //builder.HasKey(ca => new { ca.UserId, ca.CustomerId });


            builder.HasOne(x => x.User)
                   .WithMany(x => x.UserCustomerApplications)
                   .HasForeignKey(x => x.UserId)
                    .IsRequired();

            builder.HasOne(x => x.Customer)
                   .WithMany(x => x.UserCustomerApplications)
                   .HasForeignKey(x => x.CustomerId)
                   .IsRequired();

            builder.HasOne(x => x.Application)
                   .WithMany(x => x.UserCustomerApplications)
                   .HasForeignKey(x => x.ApplicationId)
                   .IsRequired();
        }
    }
}
