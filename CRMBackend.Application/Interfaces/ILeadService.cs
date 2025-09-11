using CRM.Application.Dtos.Lead;
using CRM.Domain.Enums;

namespace CRM.Application.Services.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadDto>> GetLeadsByStatusAsync(LeadStatus status);
        Task<IEnumerable<LeadDto>> GetLeadsByCustomerIdAsync(int customerId);
        Task<LeadDto?> GetLeadByIdAsync(int leadId);
        Task<LeadDto> CreateLeadAsync(CreateLeadDto dto);
        Task<LeadDto?> UpdateLeadAsync(int leadId, UpdateLeadDto dto);
        Task<bool> DeleteLeadAsync(int leadId);
    }
}
