using Data.Entity.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
           builder.HasOne(p => p.Customer)
                  .WithMany(c => c.People)
                  .HasForeignKey(p => p.CustomerId);
        }
    }
}
