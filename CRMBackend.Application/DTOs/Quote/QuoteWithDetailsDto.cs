namespace CRM.Application.Dtos.Quote
{
    public class QuoteWithDetailsDto
    {
        public int QuoteId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;

        public int OpportunityId { get; set; }
        public string OpportunityName { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
    }
}
