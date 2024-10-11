using Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class BusinessAreaTypeRelationshipConfiguration : IEntityTypeConfiguration<BusinessAreaTypeRelationship>
    {
        public void Configure(EntityTypeBuilder<BusinessAreaTypeRelationship> builder)
        {
            builder.HasKey(vb => new { vb.ParentTypeId, vb.ChildTypeId });

            builder.HasOne(vb => vb.ParentType)
                   .WithMany(bat => bat.ParentRelationships)
                   .HasForeignKey(vb => vb.ParentTypeId);

            builder.HasOne(vb => vb.ChildType)
                   .WithMany(bat => bat.ChildRelationships)
                   .HasForeignKey(vb => vb.ChildTypeId);
        }
    }
}
