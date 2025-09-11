using AutoMapper;
using CRM.Application.Dtos.Quote;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;

namespace CRM.Application.Services.Implementations
{
    public class QuoteService : IQuoteService
    {
        private readonly IQuoteRepository _quoteRepository;
        private readonly IMapper _mapper;

        public QuoteService(IQuoteRepository quoteRepository, IMapper mapper)
        {
            _quoteRepository = quoteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuoteDto>> GetQuotesByCustomerIdAsync(int customerId)
        {
            var quotes = await _quoteRepository.GetQuotesByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<QuoteDto>>(quotes);
        }

        public async Task<QuoteDto?> GetQuoteByIdAsync(int quoteId)
        {
            var quote = await _quoteRepository.GetByIdAsync(quoteId);
            return quote == null ? null : _mapper.Map<QuoteDto>(quote);
        }

        public async Task<IEnumerable<QuoteDto>> GetAllQuotesAsync()
        {
            var quotes = await _quoteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuoteDto>>(quotes);
        }

        public async Task<QuoteDto> CreateQuoteAsync(CreateQuoteDto dto)
        {
            var entity = _mapper.Map<Quote>(dto);
            await _quoteRepository.AddAsync(entity);
            return _mapper.Map<QuoteDto>(entity);
        }

        public async Task<QuoteDto?> UpdateQuoteAsync(int quoteId, UpdateQuoteDto dto)
        {
            var existing = await _quoteRepository.GetByIdAsync(quoteId);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            await _quoteRepository.UpdateAsync(existing);
            return _mapper.Map<QuoteDto>(existing);
        }

        public async Task<bool> DeleteQuoteAsync(int quoteId)
        {
            var existing = await _quoteRepository.GetByIdAsync(quoteId);
            if (existing == null) return false;

            await _quoteRepository.DeleteAsync(existing);
            return true;
        }
    }
}
