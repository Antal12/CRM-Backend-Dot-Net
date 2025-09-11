namespace CRM.Domain.Entities
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }
        public string EntityName { get; set; } = null!;
        public string Action { get; set; } = null!;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public string Changes { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
