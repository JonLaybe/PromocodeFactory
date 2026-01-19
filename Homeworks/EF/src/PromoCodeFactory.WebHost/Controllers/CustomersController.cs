using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Repositories.Interfaces.Customers;
using PromoCodeFactory.Core.Repositories.Interfaces.Preferences;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController
        : ControllerBase
    {

        private ICustomerRepository customerRepository;
        private IPreferenceRepository preferenceRepository;

        public CustomersController(ICustomerRepository customerRepository,
            IPreferenceRepository preferenceRepository)
        {
            this.customerRepository = customerRepository;
            this.preferenceRepository = preferenceRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<CustomerShortResponse>> GetCustomersAsync()
        {
            //TODO: Добавить получение списка клиентов

            var customers = await this.customerRepository.GetCustomersAsync();

            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            //TODO: Добавить получение клиента вместе с выданными ему промомкодами
            try
            {
                var customer = await this.customerRepository.GetCustomerAsync(id);

                return Ok(customer);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateOrEditCustomerRequest request)
        {
            //TODO: Добавить создание нового клиента вместе с его предпочтениями
            try
            {
                var preferences = await this.preferenceRepository
                    .GetPreferenceByIdsAsync(request.PreferenceIds);

                await this.customerRepository.CreateCustomerAsync(new Customer()
                {
                    Id = Guid.NewGuid(),
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Preference = preferences,
                });

                await this.customerRepository.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomersAsync(Guid id, [FromBody] CreateOrEditCustomerRequest request)
        {
            //TODO: Обновить данные клиента вместе с его предпочтениями

            IList<Preference> preferences = null;

            if (request.PreferenceIds.Count > 0)
                preferences = await this.preferenceRepository
                    .GetPreferenceByIdsAsync(request.PreferenceIds);

            await this.customerRepository.EditCustomersAsync(id, new Customer()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Preference = preferences,
            });

            await this.customerRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            //TODO: Удаление клиента вместе с выданными ему промокодами
            try
            {
                await this.customerRepository.DeleteCustomerAsync(id);

                await this.customerRepository.SaveChangesAsync();

                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest();
            }
        }
    }
}