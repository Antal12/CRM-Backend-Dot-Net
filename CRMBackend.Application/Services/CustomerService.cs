using AutoMapper;
using CRM.Application.Dtos.Customer;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CustomerDto>>(customers);
        }

        public async Task<CustomerWithDetailsDto?> GetByIdAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            return _mapper.Map<CustomerWithDetailsDto?>(customer);
        }

        public async Task<CustomerWithDetailsDto?> GetByEmailAsync(string email)
        {
            var customer = await _customerRepository.GetByEmailAsync(email);
            return _mapper.Map<CustomerWithDetailsDto?>(customer);
        }

        public async Task<CustomerDto> CreateAsync(CreateCustomerDto dto)
        {
            var customer = _mapper.Map<Customer>(dto);
            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task UpdateAsync(int customerId, UpdateCustomerDto dto)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null) return;

            _mapper.Map(dto, customer);
            await _customerRepository.UpdateAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer == null) return;

            await _customerRepository.DeleteAsync(customer);
            await _customerRepository.SaveChangesAsync();
        }
    }
}
