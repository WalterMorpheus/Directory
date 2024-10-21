using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class CustomerBusinessAreaConfiguration : IEntityTypeConfiguration<CustomerBusinessArea>
    {
        public void Configure(EntityTypeBuilder<CustomerBusinessArea> builder)
        {
            builder.HasKey(cb => new { cb.CustomerId, cb.BusinessAreaId });

            builder.HasOne(cb => cb.Customer)
                   .WithMany(c => c.CustomerBusinessAreas)
                   .HasForeignKey(cb => cb.CustomerId);

            builder.HasOne(cb => cb.BusinessArea)
                   .WithMany(ba => ba.CustomerBusinessAreas)
                   .HasForeignKey(cb => cb.BusinessAreaId);
        }
    }
}
