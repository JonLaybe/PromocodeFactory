using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.Interfaces.PromoCodes
{
    public interface IPromoCodeRepository
    {
        Task<IList<PromoCode>> GetPromoCodesAsync();

        Task AddPromoCodeAsync(PromoCode promoCode);
    }
}
