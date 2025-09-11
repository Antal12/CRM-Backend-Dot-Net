using CRM.Domain.Entities;
using CRM.Domain.Enums;

namespace CRM.Application.Interfaces
{
    public interface ILeadRepository
    {
        // 🔹 Custom Queries
        Task<IEnumerable<Lead>> GetLeadsByStatusAsync(LeadStatus status);
        Task<IEnumerable<Lead>> GetLeadsByCustomerIdAsync(int customerId);

        // 🔹 Basic CRUD
        Task<Lead?> GetByIdAsync(int id);
        Task<IEnumerable<Lead>> GetAllAsync();
        Task AddAsync(Lead entity);
        Task UpdateAsync(Lead entity);
        Task DeleteAsync(Lead entity);
    }
}
