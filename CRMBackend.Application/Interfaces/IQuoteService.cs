using CRM.Application.Dtos.Quote;

namespace CRM.Application.Services.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteDto>> GetQuotesByCustomerIdAsync(int customerId);
        Task<QuoteDto?> GetQuoteByIdAsync(int quoteId);
        Task<IEnumerable<QuoteDto>> GetAllQuotesAsync();
        Task<QuoteDto> CreateQuoteAsync(CreateQuoteDto dto);
        Task<QuoteDto?> UpdateQuoteAsync(int quoteId, UpdateQuoteDto dto);
        Task<bool> DeleteQuoteAsync(int quoteId);
    }
}
