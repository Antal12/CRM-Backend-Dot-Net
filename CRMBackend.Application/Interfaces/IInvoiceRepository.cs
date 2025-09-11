using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IInvoiceRepository
    {
        // 🔹 CRUD
        Task<Invoice?> GetByIdAsync(int id);
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task AddAsync(Invoice entity);
        Task UpdateAsync(Invoice entity);
        Task DeleteAsync(Invoice entity);

        // 🔹 Custom Queries
        Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(InvoiceStatus status);
        Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int customerId);
        Task<IEnumerable<Invoice>> GetInvoicesByCreatedByUserAsync(int userId);
    }
}
