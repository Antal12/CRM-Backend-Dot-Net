using CRM.Application.Dtos.Lead;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // ✅ Requires JWT for all endpoints
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;

        public LeadController(ILeadService leadService)
        {
            _leadService = leadService;
        }

        // ✅ Read Access - Allow Admin, Manager, and Sales roles
        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<IEnumerable<LeadDto>>> GetLeadsByStatus(LeadStatus status)
        {
            var leads = await _leadService.GetLeadsByStatusAsync(status);
            return Ok(leads);
        }

        [HttpGet("customer/{customerId}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<IEnumerable<LeadDto>>> GetLeadsByCustomer(int customerId)
        {
            var leads = await _leadService.GetLeadsByCustomerIdAsync(customerId);
            return Ok(leads);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<LeadDto>> GetLeadById(int id)
        {
            var lead = await _leadService.GetLeadByIdAsync(id);
            if (lead == null) return NotFound();
            return Ok(lead);
        }

        // ✅ Create - Only Admin and Sales can create leads
        [HttpPost]
        [Authorize(Roles = "Admin,Sales")]
        public async Task<ActionResult<LeadDto>> CreateLead([FromBody] CreateLeadDto dto)
        {
            var lead = await _leadService.CreateLeadAsync(dto);
            return CreatedAtAction(nameof(GetLeadById), new { id = lead.LeadId }, lead);
        }

        // ✅ Update - Admin and Sales can update
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Sales")]
        public async Task<ActionResult<LeadDto>> UpdateLead(int id, [FromBody] UpdateLeadDto dto)
        {
            var updated = await _leadService.UpdateLeadAsync(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        // ✅ Delete - Only Admin can delete
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var deleted = await _leadService.DeleteLeadAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
