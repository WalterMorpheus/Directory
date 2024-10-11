using Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class BusinessAreaRelationshipConfiguration : IEntityTypeConfiguration<BusinessAreaRelationship>
    {
        public void Configure(EntityTypeBuilder<BusinessAreaRelationship> builder)
        {
            builder.HasKey(br => new { br.ParentBusinessAreaId, br.ChildBusinessAreaId });

            builder.HasOne(br => br.ParentBusinessArea)
                   .WithMany(ba => ba.ParentRelationships)
                   .HasForeignKey(br => br.ParentBusinessAreaId);

            builder.HasOne(br => br.ChildBusinessArea)
                   .WithMany(ba => ba.ChildRelationships)
                   .HasForeignKey(br => br.ChildBusinessAreaId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
