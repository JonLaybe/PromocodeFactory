using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.Interfaces.Preferences
{
    public interface IPreferenceRepository
    {
        Task<IList<Preference>> GetPreferenceByIdsAsync(IReadOnlyList<Guid> PreferenceIds);
    }
}
