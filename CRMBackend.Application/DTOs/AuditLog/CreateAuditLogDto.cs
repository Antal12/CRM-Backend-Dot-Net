namespace CRM.Application.Dtos.AuditLog
{
    public class CreateAuditLogDto
    {
        public string EntityName { get; set; } = string.Empty;
        public string Action { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string Changes { get; set; } = string.Empty;
    }
}
