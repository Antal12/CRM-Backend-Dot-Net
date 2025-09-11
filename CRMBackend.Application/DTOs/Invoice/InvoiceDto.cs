using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Invoice
{
    public class InvoiceDto
    {
        public int InvoiceId { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
    }
}
