using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IAuditLogRepository
    {
        // 🔹 CRUD
        Task<AuditLog?> GetByIdAsync(int id);
        Task<IEnumerable<AuditLog>> GetAllAsync();
        Task AddAsync(AuditLog entity);
        Task UpdateAsync(AuditLog entity);
        Task DeleteAsync(AuditLog entity);

        // 🔹 Custom Queries
        Task<IEnumerable<AuditLog>> GetLogsByUserIdAsync(int userId);
        Task<IEnumerable<AuditLog>> GetLogsByEntityAsync(string entityName);
    }
}
