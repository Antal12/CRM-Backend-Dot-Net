using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Invoice
{
    public class CreateInvoiceDto
    {
        public decimal Amount { get; set; }
        public InvoiceStatus Status { get; set; }

        public int CustomerId { get; set; }
        public int CreatedByUserId { get; set; }
    }
}
