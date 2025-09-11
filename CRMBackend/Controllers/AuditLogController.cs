using CRM.Application.Dtos.AuditLog;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // JWT Authentication
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditLogService _auditLogService;

        public AuditLogController(IAuditLogService auditLogService)
        {
            _auditLogService = auditLogService;
        }

        // GET: api/AuditLog
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")] // Only Admin & Manager can view all logs
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetAll()
        {
            var logs = await _auditLogService.GetAllAsync();
            return Ok(logs);
        }

        // GET: api/AuditLog/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<AuditLogDto>> GetById(int id)
        {
            var log = await _auditLogService.GetByIdAsync(id);
            if (log == null) return NotFound();
            return Ok(log);
        }

        // POST: api/AuditLog
        [HttpPost]
        [Authorize(Roles = "Admin")] // Only Admin can create logs
        public async Task<ActionResult<AuditLogDto>> Create([FromBody] CreateAuditLogDto dto)
        {
            var log = await _auditLogService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = log.AuditLogId }, log);
        }

        // PUT: api/AuditLog/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can update logs
        public async Task<ActionResult> Update(int id, [FromBody] UpdateAuditLogDto dto)
        {
            var result = await _auditLogService.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        // DELETE: api/AuditLog/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete logs
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _auditLogService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // GET: api/AuditLog/User/3
        [HttpGet("User/{userId}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetLogsByUser(int userId)
        {
            var logs = await _auditLogService.GetLogsByUserIdAsync(userId);
            return Ok(logs);
        }

        // GET: api/AuditLog/Entity/Customer
        [HttpGet("Entity/{entityName}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetLogsByEntity(string entityName)
        {
            var logs = await _auditLogService.GetLogsByEntityAsync(entityName);
            return Ok(logs);
        }
    }
}
