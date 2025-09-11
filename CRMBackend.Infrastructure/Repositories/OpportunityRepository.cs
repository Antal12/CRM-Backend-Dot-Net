using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using CRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly AppDbContext _context;

        public OpportunityRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 CRUD Operations
        public async Task<Opportunity?> GetByIdAsync(int id)
        {
            return await _context.Opportunities
                .Include(o => o.Customer)
                .Include(o => o.OwnerUser)
                .FirstOrDefaultAsync(o => o.OpportunityId == id);
        }

        public async Task<IEnumerable<Opportunity>> GetAllAsync()
        {
            return await _context.Opportunities
                .Include(o => o.Customer)
                .Include(o => o.OwnerUser)
                .ToListAsync();
        }

        public async Task AddAsync(Opportunity entity)
        {
            _context.Opportunities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Opportunity entity)
        {
            _context.Opportunities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Opportunity entity)
        {
            _context.Opportunities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<Opportunity>> GetOpportunitiesByStageAsync(OpportunityStage stage)
        {
            return await _context.Opportunities
                .Include(o => o.Customer)
                .Include(o => o.OwnerUser)
                .Where(o => o.Stage == stage)
                .ToListAsync();
        }

        public async Task<IEnumerable<Opportunity>> GetOpportunitiesByCustomerIdAsync(int customerId)
        {
            return await _context.Opportunities
                .Include(o => o.Customer)
                .Include(o => o.OwnerUser)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Opportunity>> GetOpportunitiesByOwnerAsync(int ownerUserId)
        {
            return await _context.Opportunities
                .Include(o => o.Customer)
                .Include(o => o.OwnerUser)
                .Where(o => o.OwnerUserId == ownerUserId)
                .ToListAsync();
        }
    }
}
