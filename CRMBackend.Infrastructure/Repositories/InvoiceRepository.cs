using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using CRM.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CRM.Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _context;

        public InvoiceRepository(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 CRUD Methods
        public async Task<Invoice?> GetByIdAsync(int id)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.CreatedByUser)
                .FirstOrDefaultAsync(i => i.InvoiceId == id);
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.CreatedByUser)
                .ToListAsync();
        }

        public async Task AddAsync(Invoice entity)
        {
            _context.Invoices.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Invoice entity)
        {
            _context.Invoices.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Invoice entity)
        {
            _context.Invoices.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<Invoice>> GetInvoicesByStatusAsync(InvoiceStatus status)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.CreatedByUser)
                .Where(i => i.Status == status)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByCustomerIdAsync(int customerId)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.CreatedByUser)
                .Where(i => i.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByCreatedByUserAsync(int userId)
        {
            return await _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.CreatedByUser)
                .Where(i => i.CreatedByUserId == userId)
                .ToListAsync();
        }
    }
}
