using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Report
{
    public class ReportDto
    {
        public int ReportId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ReportType { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        public int GeneratedByUserId { get; set; }
        public string GeneratedByUserName { get; set; } = string.Empty;
    }
}
