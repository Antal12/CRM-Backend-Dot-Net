using AutoMapper;
using CRM.Application.Dtos.Invoice;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repository;
        private readonly IMapper _mapper;

        public InvoiceService(IInvoiceRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // 🔹 CRUD Methods
        public async Task<IEnumerable<InvoiceDto>> GetAllAsync()
        {
            var invoices = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<InvoiceDto?> GetByIdAsync(int id)
        {
            var invoice = await _repository.GetByIdAsync(id);
            if (invoice == null) return null;

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<InvoiceDto> CreateAsync(CreateInvoiceDto dto)
        {
            var invoice = _mapper.Map<Invoice>(dto);
            await _repository.AddAsync(invoice);

            return _mapper.Map<InvoiceDto>(invoice);
        }

        public async Task<bool> UpdateAsync(int id, UpdateInvoiceDto dto)
        {
            var invoice = await _repository.GetByIdAsync(id);
            if (invoice == null) return false;

            _mapper.Map(dto, invoice);
            await _repository.UpdateAsync(invoice);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var invoice = await _repository.GetByIdAsync(id);
            if (invoice == null) return false;

            await _repository.DeleteAsync(invoice);
            return true;
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<InvoiceDto>> GetByStatusAsync(InvoiceStatus status)
        {
            var invoices = await _repository.GetInvoicesByStatusAsync(status);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<IEnumerable<InvoiceDto>> GetByCustomerIdAsync(int customerId)
        {
            var invoices = await _repository.GetInvoicesByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }

        public async Task<IEnumerable<InvoiceDto>> GetByCreatedByUserAsync(int userId)
        {
            var invoices = await _repository.GetInvoicesByCreatedByUserAsync(userId);
            return _mapper.Map<IEnumerable<InvoiceDto>>(invoices);
        }
    }
}
