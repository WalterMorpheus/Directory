using Domain.Entity.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.EntityTypeConfiguration
{
    public class IdentityUserTokenConfiguration : IEntityTypeConfiguration<IdentityUserToken>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken> builder)
        {
            builder.ToTable("asp_net_user_tokens");
        }
    }
}
