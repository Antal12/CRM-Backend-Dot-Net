using CRM.Application.Dtos.Notification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface INotificationService
    {
        Task<IEnumerable<NotificationDto>> GetAllAsync();
        Task<NotificationDto?> GetByIdAsync(int id);
        Task<NotificationDto> CreateAsync(CreateNotificationDto dto);
        Task<bool> UpdateAsync(int id, UpdateNotificationDto dto);
        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<NotificationDto>> GetNotificationsByUserIdAsync(int userId);
        Task<IEnumerable<NotificationDto>> GetUnreadNotificationsByUserIdAsync(int userId);
    }
}
