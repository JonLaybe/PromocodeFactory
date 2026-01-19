using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.DataAccess.Persistence.Configurations.Roles
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            _ = builder.Property(x => x.Name).HasMaxLength(50);

            _ = builder.Property(x => x.Description).HasMaxLength(250);
        }
    }
}
