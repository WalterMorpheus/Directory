using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class BusinessAreaTypeConfiguration : IEntityTypeConfiguration<BusinessAreaType>
    {
        public void Configure(EntityTypeBuilder<BusinessAreaType> builder)
        {
            builder.HasIndex(bat => bat.Name)
                   .IsUnique();
            builder.Property(e => e.AlternateId)
                .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
