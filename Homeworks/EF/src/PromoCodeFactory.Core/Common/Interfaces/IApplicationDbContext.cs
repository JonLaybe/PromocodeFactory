using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Employee> Employees { get; }

        DbSet<Role> Roles { get; }

        DbSet<Customer> Customers { get; }

        DbSet<Preference> Preferences { get; }

        DbSet<PromoCode> PromoCodes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
