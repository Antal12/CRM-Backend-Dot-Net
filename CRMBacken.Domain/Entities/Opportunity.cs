using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Opportunity
    {
        public int OpportunityId { get; set; }
        public string OpportunityName { get; set; } = string.Empty;
        public OpportunityStage Stage { get; set; } // ✅ Enum

        // 🔗 Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // 🔗 Owner
        public int OwnerUserId { get; set; }
        public User OwnerUser { get; set; } = null!;

        // 🔗 Quotes
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
    }
}
