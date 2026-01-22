using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Common.Interfaces;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Repositories.Interfaces.Preferences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.Preferences
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private IApplicationDbContext applicationDbContext;

        public PreferenceRepository(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<IList<Preference>> GetAllPreferencesAsync() =>
            await this.applicationDbContext.Preferences.ToListAsync();

        public async Task<Preference> GetPreferenceByIdAsync(Guid id)
        {
            var preferance = await this.applicationDbContext.Preferences
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (preferance == null)
                throw new ArgumentNullException();

            return preferance;
        }

        public async Task<IList<Preference>> GetListPreferencesByIdsAsync(IReadOnlyList<Guid> PreferenceIds)
        {
            var preferences = await this.applicationDbContext.Preferences
                .Where(x => PreferenceIds.Contains(x.Id)).ToListAsync();

            if (preferences.Count == 0)
                throw new ArgumentNullException();

            return preferences;
        }
    }
}
