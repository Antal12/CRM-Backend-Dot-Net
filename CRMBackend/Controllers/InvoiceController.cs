using CRM.Application.Dtos.Invoice;
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
    [Authorize] // JWT authentication applied globally
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _service;

        public InvoiceController(IInvoiceService service)
        {
            _service = service;
        }

        // 🔹 GET: api/Invoice
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetAll()
        {
            var invoices = await _service.GetAllAsync();
            return Ok(invoices);
        }

        // 🔹 GET: api/Invoice/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<InvoiceDto>> GetById(int id)
        {
            var invoice = await _service.GetByIdAsync(id);
            if (invoice == null) return NotFound();
            return Ok(invoice);
        }

        // 🔹 POST: api/Invoice
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")] // Only Admin & Manager can create
        public async Task<ActionResult<InvoiceDto>> Create([FromBody] CreateInvoiceDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.InvoiceId }, created);
        }

        // 🔹 PUT: api/Invoice/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin & Manager can update
        public async Task<IActionResult> Update(int id, [FromBody] UpdateInvoiceDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }

        // 🔹 DELETE: api/Invoice/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        // 🔹 GET: api/Invoice/status/Paid
        [HttpGet("status/{status}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetByStatus(string status)
        {
            if (!Enum.TryParse(status, true, out InvoiceStatus parsedStatus))
                return BadRequest("Invalid status value");

            var invoices = await _service.GetByStatusAsync(parsedStatus);
            return Ok(invoices);
        }

        // 🔹 GET: api/Invoice/customer/5
        [HttpGet("customer/{customerId}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetByCustomer(int customerId)
        {
            var invoices = await _service.GetByCustomerIdAsync(customerId);
            return Ok(invoices);
        }

        // 🔹 GET: api/Invoice/createdby/5
        [HttpGet("createdby/{userId}")]
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<ActionResult<IEnumerable<InvoiceDto>>> GetByCreatedByUser(int userId)
        {
            var invoices = await _service.GetByCreatedByUserAsync(userId);
            return Ok(invoices);
        }
    }
}
