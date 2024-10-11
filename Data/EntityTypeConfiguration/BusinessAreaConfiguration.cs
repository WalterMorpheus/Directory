using Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class BusinessAreaConfiguration : IEntityTypeConfiguration<BusinessArea>
    {
        public void Configure(EntityTypeBuilder<BusinessArea> builder)
        {
            builder.HasOne(ba => ba.Customer)
                   .WithMany(c => c.BusinessAreas)
                   .HasForeignKey(ba => ba.CustomerId);

            builder.HasOne(ba => ba.BusinessAreaType)
                   .WithMany(bat => bat.BusinessAreas)
                   .HasForeignKey(ba => ba.BusinessAreaTypeId);
        }
    }
}
