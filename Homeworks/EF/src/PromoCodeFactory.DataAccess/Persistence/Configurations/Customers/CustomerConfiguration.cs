using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess.Persistence.Configurations.Customers
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            _ = builder.Property(x => x.FirstName).HasMaxLength(50);

            _ = builder.Property(x => x.LastName).HasMaxLength(50);

            _ = builder.Property(x => x.Email).HasMaxLength(250);

            _ = builder.HasMany(c => c.Preference)
                .WithMany();

            _ = builder.HasMany(c => c.PromoCode)
                .WithMany();
        }
    }
}
