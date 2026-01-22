using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Repositories.Interfaces.PromoCodes;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController
        : ControllerBase
    {
        private IPromoCodeRepository promoCodeRepository;

        public PromocodesController(IPromoCodeRepository promoCodeRepository)
        {
            this.promoCodeRepository = promoCodeRepository;
        }

        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<PromoCodeShortResponse>>> GetPromocodesAsync()
        {
            //TODO: Получить все промокоды 
            var promoCodes = await this.promoCodeRepository.GetPromoCodesAsync();

            return Ok(promoCodes.Select(x => new PromoCodeShortResponse()
            {
                Id = x.Id,
                Code = x.Code,
                PartnerName = x.PartnerName,
                ServiceInfo = x.ServiceInfo,
                BeginDate = x.BeginDate.ToString("dd:MM:yyyy"),
                EndDate = x.BeginDate.ToString("dd:MM:yyyy")
            }));
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PromoCodeResponse>> GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            //TODO: Создать промокод и выдать его клиентам с указанным предпочтением
            var newPromoCode = new PromoCode()
            {
                Code = request.PromoCode,
                PartnerName = request.PartnerName,
                ServiceInfo = request.ServiceInfo,
            };

            await this.promoCodeRepository.AddPromoCodeAsync(newPromoCode);

            return Ok(newPromoCode);
        }
    }
}