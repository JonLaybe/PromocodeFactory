using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Common.Interfaces;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Repositories.Interfaces.PromoCodes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.PromoCodes
{
    public class PromoCodeRepository : IPromoCodeRepository
    {
        private IApplicationDbContext applicationDbContext;

        public PromoCodeRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IList<PromoCode>> GetPromoCodesAsync() =>
            await this.applicationDbContext.PromoCodes.ToListAsync();

        public async Task AddPromoCodeAsync(PromoCode promoCode) =>
            await this.applicationDbContext.PromoCodes.AddAsync(promoCode);
    }
}
