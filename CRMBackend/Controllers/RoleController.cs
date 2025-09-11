using CRM.Application.Dtos.Role;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")] // Restrict all endpoints to Admins
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/role
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
            return Ok(roles);
        }

        // GET: api/role/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
            if (role == null) return NotFound(new { message = "Role not found" });
            return Ok(role);
        }

        // POST: api/role
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            // ✅ No manual ModelState check needed – ValidationFilter + FluentValidation handle it
            var role = await _roleService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = role.RoleId }, role);
        }

        // PUT: api/role/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto dto)
        {
            var existingRole = await _roleService.GetByIdAsync(id);
            if (existingRole == null)
                return NotFound(new { message = "Role not found" });

            await _roleService.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/role/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingRole = await _roleService.GetByIdAsync(id);
            if (existingRole == null)
                return NotFound(new { message = "Role not found" });

            await _roleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
