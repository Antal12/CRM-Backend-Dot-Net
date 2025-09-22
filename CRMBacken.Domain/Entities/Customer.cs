namespace CRM.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        //add new property

        // 🔗 Assigned User (Sales Rep, Manager etc.)
        public int AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; } = null!;

        // 🔗 One-to-Many
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
