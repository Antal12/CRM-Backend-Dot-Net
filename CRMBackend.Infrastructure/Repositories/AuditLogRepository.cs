using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Infrastructure.Persistence;
using CRMBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Repositories
{
    public class AuditLogRepository : IAuditLogRepository
    {
        private readonly AppDbContext _context;

        public AuditLogRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 CRUD Methods
        public async Task<AuditLog?> GetByIdAsync(int id)
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.AuditLogId == id);
        }

        public async Task<IEnumerable<AuditLog>> GetAllAsync()
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .ToListAsync();
        }

        public async Task AddAsync(AuditLog entity)
        {
            _context.AuditLogs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AuditLog entity)
        {
            _context.AuditLogs.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AuditLog entity)
        {
            _context.AuditLogs.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<AuditLog>> GetLogsByUserIdAsync(int userId)
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByEntityAsync(string entityName)
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .Where(a => a.EntityName == entityName)
                .ToListAsync();
        }
    }
}
