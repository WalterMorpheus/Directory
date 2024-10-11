using Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class CustomerApplicationConfiguration : IEntityTypeConfiguration<CustomerApplication>
    {
        public void Configure(EntityTypeBuilder<CustomerApplication> builder)
        {
            builder.HasKey(ca => new { ca.CustomerId, ca.ApplicationId });

            builder.HasOne(ca => ca.Customer)
                   .WithMany(c => c.CustomerApplications)
                   .HasForeignKey(ca => ca.CustomerId);

            builder.HasOne(ca => ca.Application)
                   .WithMany(a => a.CustomerApplications)
                   .HasForeignKey(ca => ca.ApplicationId);
        }
    }
}
