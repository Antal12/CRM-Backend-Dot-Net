using CRM.Application.Dtos.Opportunity;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // JWT authorization applied globally to this controller
    public class OpportunityController : ControllerBase
    {
        private readonly IOpportunityService _service;

        public OpportunityController(IOpportunityService service)
        {
            _service = service;
        }

        // 🔹 GET: api/Opportunity
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,User")] // Role-based access
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> GetAll()
        {
            var opportunities = await _service.GetAllAsync();
            return Ok(opportunities);
        }

        // 🔹 GET: api/Opportunity/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<OpportunityDto>> GetById(int id)
        {
            var opportunity = await _service.GetByIdAsync(id);
            if (opportunity == null) return NotFound();
            return Ok(opportunity);
        }

        // 🔹 POST: api/Opportunity
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")] // Only Admin & Manager can create
        public async Task<ActionResult<OpportunityDto>> Create([FromBody] CreateOpportunityDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.OpportunityId }, created);
        }

        // 🔹 PUT: api/Opportunity/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin & Manager can update
        public async Task<IActionResult> Update(int id, [FromBody] UpdateOpportunityDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        // 🔹 DELETE: api/Opportunity/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // 🔹 GET: api/Opportunity/stage/Prospecting
        [HttpGet("stage/{stage}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> GetByStage(string stage)
        {
            if (!Enum.TryParse(stage, true, out OpportunityStage parsedStage))
                return BadRequest("Invalid stage value");

            var opportunities = await _service.GetByStageAsync(parsedStage);
            return Ok(opportunities);
        }

        // 🔹 GET: api/Opportunity/customer/5
        [HttpGet("customer/{customerId}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> GetByCustomer(int customerId)
        {
            var opportunities = await _service.GetByCustomerIdAsync(customerId);
            return Ok(opportunities);
        }

        // 🔹 GET: api/Opportunity/owner/5
        [HttpGet("owner/{ownerUserId}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<OpportunityDto>>> GetByOwner(int ownerUserId)
        {
            var opportunities = await _service.GetByOwnerAsync(ownerUserId);
            return Ok(opportunities);
        }
    }
}
