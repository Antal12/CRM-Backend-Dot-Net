using CRM.Application.Dtos.Report;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IReportService
    {
        Task<IEnumerable<ReportDto>> GetAllAsync();
        Task<ReportDto?> GetByIdAsync(int id);
        Task<ReportDto> CreateAsync(CreateReportDto dto);
        Task<bool> UpdateAsync(int id, UpdateReportDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<ReportDto>> GetReportsByTypeAsync(string reportType);
        Task<IEnumerable<ReportDto>> GetReportsByUserAsync(int userId);
    }
}
