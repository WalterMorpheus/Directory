using Domain.Entity.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class IdentityRoleClaimConfiguration : IEntityTypeConfiguration<IdentityRoleClaim>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim> builder)
        {
            builder.ToTable("asp_net_role_claims");
            builder.Property(e => e.AlternateId)
                .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}
