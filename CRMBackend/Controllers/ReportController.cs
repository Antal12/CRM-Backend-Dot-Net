using CRM.Application.Dtos.Report;
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
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // GET: api/Report
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<ReportDto>>> GetAll()
        {
            var reports = await _service.GetAllAsync();
            return Ok(reports);
        }

        // GET: api/Report/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<ReportDto>> GetById(int id)
        {
            var report = await _service.GetByIdAsync(id);
            if (report == null) return NotFound();
            return Ok(report);
        }

        // POST: api/Report
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ReportDto>> Create([FromBody] CreateReportDto dto)
        {
            var report = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = report.ReportId }, report);
        }

        // PUT: api/Report/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ReportDto>> Update(int id, [FromBody] UpdateReportDto dto)
        {
            var updatedReport = await _service.UpdateAsync(id, dto);
            if (updatedReport == null) return NotFound();
            return Ok(updatedReport);
        }

        // DELETE: api/Report/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
