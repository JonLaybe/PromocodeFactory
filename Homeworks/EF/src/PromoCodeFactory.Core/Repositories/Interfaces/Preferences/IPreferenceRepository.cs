using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.Interfaces.Preferences
{
    public interface IPreferenceRepository
    {
        Task<Preference> GetPreferenceByIdAsync(Guid id);

        Task<IList<Preference>> GetAllPreferencesAsync();

        Task<IList<Preference>> GetListPreferencesByIdsAsync(IReadOnlyList<Guid> PreferenceIds);
    }
}
