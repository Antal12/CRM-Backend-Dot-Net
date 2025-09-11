using CRM.Domain.Entities;
using CRM.Domain.Enums;

namespace CRM.Application.Interfaces
{
    public interface IOpportunityRepository
    {
        // 🔹 CRUD
        Task<Opportunity?> GetByIdAsync(int id);
        Task<IEnumerable<Opportunity>> GetAllAsync();
        Task AddAsync(Opportunity entity);
        Task UpdateAsync(Opportunity entity);
        Task DeleteAsync(Opportunity entity);

        // 🔹 Custom Queries
        Task<IEnumerable<Opportunity>> GetOpportunitiesByStageAsync(OpportunityStage stage);
        Task<IEnumerable<Opportunity>> GetOpportunitiesByCustomerIdAsync(int customerId);
        Task<IEnumerable<Opportunity>> GetOpportunitiesByOwnerAsync(int ownerUserId);
    }
}
