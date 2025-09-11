namespace CRM.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;

        // 🔗 Many-to-Many with Role
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        // 🔗 One-to-Many
        public ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
        public ICollection<Quote> Quotes { get; set; } = new List<Quote>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<Report> Reports { get; set; } = new List<Report>();

        // 🔗 Extra tracking
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
        public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    }
}
