using System.Collections.Generic;
using CRM.Application.Dtos.Lead;
using CRM.Application.Dtos.Opportunity;
using CRM.Application.Dtos.Quote;
using CRM.Application.Dtos.Invoice;

namespace CRM.Application.Dtos.Customer
{
    public class CustomerWithDetailsDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; } = string.Empty;

        public ICollection<LeadDto> Leads { get; set; } = new List<LeadDto>();
        public ICollection<OpportunityDto> Opportunities { get; set; } = new List<OpportunityDto>();
        public ICollection<QuoteDto> Quotes { get; set; } = new List<QuoteDto>();
        public ICollection<InvoiceDto> Invoices { get; set; } = new List<InvoiceDto>();
    }
}
