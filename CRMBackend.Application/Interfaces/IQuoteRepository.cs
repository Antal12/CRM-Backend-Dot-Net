using CRM.Domain.Entities;

namespace CRM.Application.Interfaces
{
    public interface IQuoteRepository
    {
        // 🔹 Custom Queries
        Task<IEnumerable<Quote>> GetQuotesByCustomerIdAsync(int customerId);
       

        // 🔹 CRUD
        Task<Quote?> GetByIdAsync(int id);
        Task<IEnumerable<Quote>> GetAllAsync();
        Task AddAsync(Quote entity);
        Task UpdateAsync(Quote entity);
        Task DeleteAsync(Quote entity);
    }
}
