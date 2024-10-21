using Domain.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class PersonBusinessAreaConfiguration : IEntityTypeConfiguration<PersonBusinessArea>
    {
        public void Configure(EntityTypeBuilder<PersonBusinessArea> builder)
        {

            builder.HasKey(pb => new { pb.PersonId, pb.BusinessAreaId });

            builder.HasOne(u => u.Person)
                   .WithMany(u => u.PersonBusinessAreas)
                   .HasForeignKey(ur => ur.PersonId)
                   .IsRequired();

            builder.HasOne(r => r.BusinessArea)
                   .WithMany(r => r.PersonBusinessAreas)
                   .HasForeignKey(r => r.BusinessAreaId)
                   .IsRequired();
        }
    }
}
