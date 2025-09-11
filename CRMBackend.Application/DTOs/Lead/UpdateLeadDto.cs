using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Lead
{
    public class UpdateLeadDto
    {
        public string LeadName { get; set; } = string.Empty;
        public LeadStatus Status { get; set; }

        public int? CustomerId { get; set; }
    }
}
