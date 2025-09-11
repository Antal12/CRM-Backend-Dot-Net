namespace CRM.Application.Dtos.Notification
{
    public class NotificationDto
    {
        public int NotificationId { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
