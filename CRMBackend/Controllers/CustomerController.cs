using CRM.Application.Dtos.Customer;
using CRM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // All endpoints require authentication
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Sales")] // Only certain roles can view all customers
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(customers);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // GET: api/customer/email/{email}
        [HttpGet("email/{email}")]
        [Authorize(Roles = "Admin,Manager,Sales")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var customer = await _customerService.GetByEmailAsync(email);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        // POST: api/customer
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager can create
        public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
        {
            var customer = await _customerService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = customer.CustomerId }, customer);
        }

        // PUT: api/customer/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")] // Only Admin or Manager can update
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCustomerDto dto)
        {
            await _customerService.UpdateAsync(id, dto);
            return NoContent();
        }

        // DELETE: api/customer/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Only Admin can delete
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
