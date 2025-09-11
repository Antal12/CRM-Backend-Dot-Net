using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public decimal Amount { get; set; }
        public QuoteStatus Status { get; set; } // ✅ Enum

        // 🔗 Opportunity
        public int OpportunityId { get; set; }
        public Opportunity Opportunity { get; set; } = null!;

        // 🔗 Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // 🔗 Created By
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;
    }
}
