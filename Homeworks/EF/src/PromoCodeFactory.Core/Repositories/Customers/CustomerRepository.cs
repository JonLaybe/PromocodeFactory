using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Common.Interfaces;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Repositories.Interfaces.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private IApplicationDbContext application;

        public CustomerRepository(IApplicationDbContext application)
        {
            this.application = application;
        }

        public async Task<IReadOnlyList<Customer>> GetCustomersAsync() =>
            await this.application.Customers
                .Include(x => x.Preference)
                .Include(x => x.PromoCode)
                .ToListAsync();

        public async Task<Customer> GetCustomerAsync(Guid id)
        {
            var customer = await this.application.Customers.Where(x => x.Id == id)
                .Include(x => x.Preference)
                .Include(x => x.PromoCode)
                .FirstOrDefaultAsync();

            if (customer == null)
                throw new ArgumentNullException();

            return customer;
        }

        public async Task CreateCustomerAsync(Customer customer) =>
            await this.application.Customers.AddAsync(customer);

        public async Task EditCustomersAsync(Guid id, Customer customer)
        {
            var selectedCustomer = await this.GetCustomerAsync(id);

            if (selectedCustomer == null)
                throw new ArgumentNullException();

            selectedCustomer.FirstName = customer.FirstName;
            selectedCustomer.LastName = customer.LastName;
            selectedCustomer.Email = customer.Email;
            selectedCustomer.Preference = customer.Preference;
        }

        public async Task DeleteCustomerAsync(Guid id)
        {
            var selectedCustomer = await this.GetCustomerAsync(id);

            this.application.Customers.Remove(selectedCustomer);
        }

        public async Task SaveChangesAsync() =>
            await this.application.SaveChangesAsync();
    }
}
