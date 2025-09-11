using CRM.Application.Dtos.User;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Require authentication
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // 👥 GET: api/user
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // 👤 GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound(new { Message = $"User with ID {id} not found." });

            return Ok(user);
        }

        // 📧 GET: api/user/email?email=someone@crm.com
        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
                return NotFound(new { Message = $"User with email {email} not found." });

            return Ok(user);
        }

        // ➕ POST: api/user
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            // ✅ FluentValidation will validate dto automatically
            var user = await _userService.CreateAsync(dto, dto.Password);
            return CreatedAtAction(nameof(GetById), new { id = user.UserId }, user);
        }

        // ✏️ PUT: api/user/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            // ✅ FluentValidation will validate dto automatically
            await _userService.UpdateAsync(id, dto);
            return NoContent();
        }

        // 🗑 DELETE: api/user/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        // 🔗 POST: api/user/{userId}/assign-role/{roleId}
        [HttpPost("{userId}/assign-role/{roleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRole(int userId, int roleId)
        {
            await _userService.AssignRoleAsync(userId, roleId);
            return Ok(new { Message = $"Role {roleId} assigned to user {userId}" });
        }
    }
}
