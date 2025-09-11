using CRM.Application.Dtos.Invoice;
using CRM.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task<IEnumerable<InvoiceDto>> GetAllAsync();
        Task<InvoiceDto?> GetByIdAsync(int id);
        Task<InvoiceDto> CreateAsync(CreateInvoiceDto dto);
        Task<bool> UpdateAsync(int id, UpdateInvoiceDto dto);
        Task<bool> DeleteAsync(int id);

        // Custom queries
        Task<IEnumerable<InvoiceDto>> GetByStatusAsync(InvoiceStatus status);
        Task<IEnumerable<InvoiceDto>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<InvoiceDto>> GetByCreatedByUserAsync(int userId);
    }
}
