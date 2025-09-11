using CRM.Domain.Enums;

namespace CRM.Domain.Entities
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStatus Status { get; set; } // ✅ Enum

        // 🔗 Customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        // 🔗 Created By
        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; } = null!;
    }
}
