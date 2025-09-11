using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IReportRepository
    {
        Task<Report?> GetByIdAsync(int id);
        Task<IEnumerable<Report>> GetAllAsync();
        Task AddAsync(Report entity);
        Task UpdateAsync(Report entity);
        Task DeleteAsync(Report entity);

        // Custom Queries
        Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType reportType);
        Task<IEnumerable<Report>> GetReportsByUserAsync(int userId);
    }
}
