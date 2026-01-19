using PromoCodeFactory.Core.Common.Interfaces;
using PromoCodeFactory.DataAccess.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Persistence
{
    public static class InitDataBase
    {
        public static async void InitAsync(IApplicationDbContext applicationDbContext)
        {
            await applicationDbContext.Preferences.AddRangeAsync(FakeDataFactory.Preferences);
            await applicationDbContext.Customers.AddRangeAsync(FakeDataFactory.Customers);
            await applicationDbContext.Employees.AddRangeAsync(FakeDataFactory.Employees);

            await applicationDbContext.SaveChangesAsync();
        }
    }
}
