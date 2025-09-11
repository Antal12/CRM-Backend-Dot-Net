namespace CRM.Application.Dtos.Notification
{
    public class CreateNotificationDto
    {
        public string Message { get; set; } = string.Empty;
        public int UserId { get; set; }
    }
}
