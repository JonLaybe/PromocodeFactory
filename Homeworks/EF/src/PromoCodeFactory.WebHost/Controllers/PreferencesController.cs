using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Repositories.Interfaces.Preferences;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Предпочтения
    /// </summary>
    [Route("api/v1/[controller]")]
    public class PreferencesController : ControllerBase
    {
        private IPreferenceRepository preferenceRepository;

        public PreferencesController(IPreferenceRepository preferenceRepository)
        {
            this.preferenceRepository = preferenceRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PrefernceResponse>> GetAllAsync()
        {
            var preferences = (await this.preferenceRepository.GetAllPreferencesAsync())
                .Select(x => new PrefernceResponse()
                {
                    Id = x.Id,
                    Name = x.Name,
                });

            return Ok(preferences);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PrefernceResponse>> GetPreferenceById(Guid id)
        {
            try
            {
                var preference = await this.preferenceRepository.GetPreferenceByIdAsync(id);

                return Ok(new PrefernceResponse()
                {
                    Id = preference.Id,
                    Name = preference.Name,
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest();
            }
        }
    }
}
