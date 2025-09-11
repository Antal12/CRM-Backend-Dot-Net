using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using CRM.Infrastructure.Persistence;
using CRMBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly AppDbContext _context;

        public LeadRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<Lead>> GetLeadsByStatusAsync(LeadStatus status)
        {
            return await _context.Leads
                .Include(l => l.Customer)
                .Include(l => l.CreatedByUser)
                .Where(l => l.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetLeadsByCustomerIdAsync(int customerId)
        {
            return await _context.Leads
                .Include(l => l.Customer)
                .Include(l => l.CreatedByUser)
                .Where(l => l.CustomerId == customerId)
                .ToListAsync();
        }

        // 🔹 CRUD Methods
        public async Task<Lead?> GetByIdAsync(int id)
        {
            return await _context.Leads
                .Include(l => l.Customer)
                .Include(l => l.CreatedByUser)
                .FirstOrDefaultAsync(l => l.LeadId == id);
        }

        public async Task<IEnumerable<Lead>> GetAllAsync()
        {
            return await _context.Leads
                .Include(l => l.Customer)
                .Include(l => l.CreatedByUser)
                .ToListAsync();
        }

        public async Task AddAsync(Lead entity)
        {
            await _context.Leads.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Lead entity)
        {
            _context.Leads.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Lead entity)
        {
            _context.Leads.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
