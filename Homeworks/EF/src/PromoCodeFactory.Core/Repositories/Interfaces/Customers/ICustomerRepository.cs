using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Repositories.Interfaces.Customers
{
    public interface ICustomerRepository
    {
        Task<IReadOnlyList<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(Guid id);

        Task CreateCustomerAsync(Customer customer);

        Task EditCustomersAsync(Guid id, Customer customer);

        Task DeleteCustomerAsync(Guid id);

        Task SaveChangesAsync();
    }
}
