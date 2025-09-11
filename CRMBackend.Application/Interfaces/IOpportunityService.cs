using CRM.Application.Dtos.Opportunity;
using CRM.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IOpportunityService
    {
        Task<IEnumerable<OpportunityDto>> GetAllAsync();
        Task<OpportunityDto?> GetByIdAsync(int id);
        Task<OpportunityDto> CreateAsync(CreateOpportunityDto dto);
        Task<bool> UpdateAsync(int id, UpdateOpportunityDto dto);
        Task<bool> DeleteAsync(int id);

        // Custom queries
        Task<IEnumerable<OpportunityDto>> GetByStageAsync(OpportunityStage stage);
        Task<IEnumerable<OpportunityDto>> GetByCustomerIdAsync(int customerId);
        Task<IEnumerable<OpportunityDto>> GetByOwnerAsync(int ownerUserId);
    }
}
