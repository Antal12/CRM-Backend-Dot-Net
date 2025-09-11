using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Opportunity
{
    public class CreateOpportunityDto
    {
        public string OpportunityName { get; set; } = string.Empty;
        public OpportunityStage Stage { get; set; }

        public int CustomerId { get; set; }
        public int OwnerUserId { get; set; }
    }
}
