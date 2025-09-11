using CRM.Application.Dtos.Notification;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // JWT Auth
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _service;

        public NotificationController(INotificationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")] // Admin & Manager
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetAll()
        {
            var notifications = await _service.GetAllAsync();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<NotificationDto>> GetById(int id)
        {
            var notification = await _service.GetByIdAsync(id);
            if (notification == null) return NotFound();
            return Ok(notification);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")] // Only Admin can create
        public async Task<ActionResult<NotificationDto>> Create([FromBody] CreateNotificationDto dto)
        {
            var notification = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = notification.NotificationId }, notification);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can update
        public async Task<ActionResult> Update(int id, [FromBody] UpdateNotificationDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpGet("User/{userId}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetByUser(int userId)
        {
            var notifications = await _service.GetNotificationsByUserIdAsync(userId);
            return Ok(notifications);
        }

        [HttpGet("User/{userId}/Unread")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetUnreadByUser(int userId)
        {
            var notifications = await _service.GetUnreadNotificationsByUserIdAsync(userId);
            return Ok(notifications);
        }
    }
}
