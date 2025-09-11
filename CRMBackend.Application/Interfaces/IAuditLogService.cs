using CRM.Application.Dtos.AuditLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<IEnumerable<AuditLogDto>> GetAllAsync();
        Task<AuditLogDto?> GetByIdAsync(int id);
        Task<AuditLogDto> CreateAsync(CreateAuditLogDto dto);
        Task<bool> UpdateAsync(int id, UpdateAuditLogDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<AuditLogDto>> GetLogsByUserIdAsync(int userId);
        Task<IEnumerable<AuditLogDto>> GetLogsByEntityAsync(string entityName);
    }
}
