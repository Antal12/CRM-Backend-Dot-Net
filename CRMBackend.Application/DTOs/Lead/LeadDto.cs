using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Lead
{
    public class LeadDto
    {
        public int LeadId { get; set; }
        public string LeadName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public int CreatedByUserId { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
    }
}
