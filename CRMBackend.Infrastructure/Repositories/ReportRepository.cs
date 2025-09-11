using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using CRM.Infrastructure.Persistence;
using CRMBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Report entity)
        {
            _context.Reports.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Report entity)
        {
            _context.Reports.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            return await _context.Reports
                .Include(r => r.GeneratedByUser)
                .ToListAsync();
        }

        public async Task<Report?> GetByIdAsync(int id)
        {
            return await _context.Reports
                .Include(r => r.GeneratedByUser)
                .FirstOrDefaultAsync(r => r.ReportId == id);
        }

        public async Task<IEnumerable<Report>> GetReportsByTypeAsync(ReportType reportType)
        {
            return await _context.Reports
                .Include(r => r.GeneratedByUser)
                .Where(r => r.ReportType == reportType)
                .ToListAsync();
        }

        public async Task<IEnumerable<Report>> GetReportsByUserAsync(int userId)
        {
            return await _context.Reports
                .Include(r => r.GeneratedByUser)
                .Where(r => r.GeneratedByUserId == userId)
                .ToListAsync();
        }

        public async Task UpdateAsync(Report entity)
        {
            _context.Reports.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
