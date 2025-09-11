using CRM.Application.Dtos.Customer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerWithDetailsDto?> GetByIdAsync(int customerId);
        Task<CustomerWithDetailsDto?> GetByEmailAsync(string email);
        Task<CustomerDto> CreateAsync(CreateCustomerDto dto);
        Task UpdateAsync(int customerId, UpdateCustomerDto dto);
        Task DeleteAsync(int customerId);
    }
}
