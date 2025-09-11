using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Quote
{
    public class CreateQuoteDto
    {
        public decimal Amount { get; set; }
        public QuoteStatus Status { get; set; }

        public int OpportunityId { get; set; }
        public int CustomerId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
