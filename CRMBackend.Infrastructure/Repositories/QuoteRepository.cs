using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Infrastructure.Persistence;
using CRMBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly AppDbContext _context;

        public QuoteRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<Quote>> GetQuotesByCustomerIdAsync(int customerId)
        {
            return await _context.Quotes
                .Include(q => q.Customer)
                .Include(q => q.CreatedByUser)
                .Where(q => q.CustomerId == customerId)
                .ToListAsync();
        }

       
        // 🔹 CRUD
        public async Task<Quote?> GetByIdAsync(int id)
        {
            return await _context.Quotes
                .Include(q => q.Customer)
                .Include(q => q.CreatedByUser)
                .FirstOrDefaultAsync(q => q.QuoteId == id);
        }

        public async Task<IEnumerable<Quote>> GetAllAsync()
        {
            return await _context.Quotes
                .Include(q => q.Customer)
                .Include(q => q.CreatedByUser)
                .ToListAsync();
        }

        public async Task AddAsync(Quote entity)
        {
            await _context.Quotes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Quote entity)
        {
            _context.Quotes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Quote entity)
        {
            _context.Quotes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
