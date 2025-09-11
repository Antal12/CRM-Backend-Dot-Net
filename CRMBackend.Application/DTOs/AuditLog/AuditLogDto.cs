namespace CRM.Application.Dtos.AuditLog
{
    public class AuditLogDto
    {
        public int AuditLogId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public string Changes { get; set; } = string.Empty;
    }
}
