using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Lead
    {
        public int LeadId { get; set; }
        public string LeadName { get; set; } = string.Empty;
        public LeadStatus Status { get; set; } // ✅ Enum

        // 🔗 Customer (optional)
        public int? CustomerId { get; set; }
        public Customer? Customer { get; set; }

        // 🔗 Created By
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;
    }
}
