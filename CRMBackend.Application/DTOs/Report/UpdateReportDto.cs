using CRM.Domain.Enums;

namespace CRM.Application.Dtos.Report
{
    public class UpdateReportDto
    {
        public string? Title { get; set; }
        public ReportType? ReportType { get; set; }
    }
}
