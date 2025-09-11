namespace CRM.Application.Dtos.Opportunity
{
    public class OpportunityWithDetailsDto
    {
        public int OpportunityId { get; set; }
        public string OpportunityName { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public int OwnerUserId { get; set; }
        public string OwnerUserName { get; set; } = string.Empty;
    }
}
