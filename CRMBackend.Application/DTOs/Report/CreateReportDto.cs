using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Report
{
    public class CreateReportDto
    {
        public string Title { get; set; } = string.Empty;
        public ReportType ReportType { get; set; }
        public int GeneratedByUserId { get; set; }
    }
}
