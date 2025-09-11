using CRM.Application.Dtos.UserRole;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")] // Only Admins can manage user roles
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        // GET: api/userrole
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _userRoleService.GetAllAsync();
            return Ok(userRoles);
        }

        // GET: api/userrole/user/{userId}
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRolesByUser(int userId)
        {
            var roles = await _userRoleService.GetRolesByUserAsync(userId);
            if (roles == null || roles.Roles.Count == 0)
                return NotFound(new { message = "No roles found for this user." });

            return Ok(roles);
        }

        // GET: api/userrole/role/{roleId}
        [HttpGet("role/{roleId}")]
        public async Task<IActionResult> GetUsersByRole(int roleId)
        {
            var users = await _userRoleService.GetUsersByRoleAsync(roleId);
            if (users == null || users.Users.Count == 0)
                return NotFound(new { message = "No users found for this role." });

            return Ok(users);
        }

        // POST: api/userrole/assign
        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            await _userRoleService.AssignRoleAsync(dto);
            return Ok(new { message = "Role assigned successfully" });
        }

        // POST: api/userrole/remove
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRole([FromBody] RemoveRoleDto dto)
        {
            await _userRoleService.RemoveRoleAsync(dto);
            return Ok(new { message = "Role removed successfully" });
        }
    }
}
