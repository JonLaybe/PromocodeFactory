using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromoCodeFactory.Core.Domain.Administration;

namespace PromoCodeFactory.DataAccess.Persistence.Configurations.Employees
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            _ = builder.Property(x => x.FirstName).HasMaxLength(50);

            _ = builder.Property(x => x.LastName).HasMaxLength(50);
            
            _ = builder.Property(x => x.Email).HasMaxLength(250);

            builder.HasOne(e => e.Role)
                   .WithMany()
                   .HasForeignKey(e => e.Id);
        }
    }
}
