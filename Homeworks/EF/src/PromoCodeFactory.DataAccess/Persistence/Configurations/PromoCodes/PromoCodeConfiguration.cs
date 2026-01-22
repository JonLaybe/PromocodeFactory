using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess.Persistence.Configurations.PromoCodes
{
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            _ = builder.Property(x => x.Code).HasMaxLength(256);

            _ = builder.Property(x => x.ServiceInfo).HasMaxLength(256);

            _ = builder.Property(x => x.PartnerName).HasMaxLength(256);
        }
    }
}
