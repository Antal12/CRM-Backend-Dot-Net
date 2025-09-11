using CRM.Application.Dtos.Quote;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // 🔐 Requires JWT Authentication
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        // ✅ Get All Quotes (accessible to Admin + Manager)
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetAll()
        {
            var quotes = await _quoteService.GetAllQuotesAsync();
            return Ok(quotes);
        }

        // ✅ Get Quote by Id (Admin, Manager, Sales)
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<QuoteDto>> GetById(int id)
        {
            var quote = await _quoteService.GetQuoteByIdAsync(id);
            if (quote == null) return NotFound();
            return Ok(quote);
        }

        // ✅ Get Quotes by Customer (Admin, Manager, Sales)
        [HttpGet("customer/{customerId:int}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<IEnumerable<QuoteDto>>> GetByCustomer(int customerId)
        {
            var quotes = await _quoteService.GetQuotesByCustomerIdAsync(customerId);
            return Ok(quotes);
        }

        // ✅ Create Quote (Sales, Manager, Admin)
        [HttpPost]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<ActionResult<QuoteDto>> Create([FromBody] CreateQuoteDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _quoteService.CreateQuoteAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.QuoteId }, created);
        }

        // ✅ Update Quote (Admin, Manager)
        [HttpPut("{id:int}")]
        [Authorize(Roles = "Admin,Manager")]
        public async Task<ActionResult<QuoteDto>> Update(int id, [FromBody] UpdateQuoteDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _quoteService.UpdateQuoteAsync(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        // ✅ Delete Quote (Admin only)
        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _quoteService.DeleteQuoteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
