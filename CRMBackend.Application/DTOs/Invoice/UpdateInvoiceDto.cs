using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Invoice
{
    public class UpdateInvoiceDto
    {
        public decimal Amount { get; set; }
        public InvoiceStatus Status { get; set; }

        public int CustomerId { get; set; }
    }
}
