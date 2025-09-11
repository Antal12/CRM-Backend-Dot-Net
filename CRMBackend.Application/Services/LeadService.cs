using AutoMapper;
using CRM.Application.Dtos.Lead;
using CRM.Application.Services.Interfaces;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;

namespace CRM.Application.Services.Implementations
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMapper _mapper;

        public LeadService(ILeadRepository leadRepository, IMapper mapper)
        {
            _leadRepository = leadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LeadDto>> GetLeadsByStatusAsync(LeadStatus status)
        {
            var leads = await _leadRepository.GetLeadsByStatusAsync(status);
            return _mapper.Map<IEnumerable<LeadDto>>(leads);
        }

        public async Task<IEnumerable<LeadDto>> GetLeadsByCustomerIdAsync(int customerId)
        {
            var leads = await _leadRepository.GetLeadsByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<LeadDto>>(leads);
        }

        public async Task<LeadDto?> GetLeadByIdAsync(int leadId)
        {
            var lead = await _leadRepository.GetByIdAsync(leadId);
            return lead == null ? null : _mapper.Map<LeadDto>(lead);
        }

        public async Task<LeadDto> CreateLeadAsync(CreateLeadDto dto)
        {
            var entity = _mapper.Map<Lead>(dto);
            await _leadRepository.AddAsync(entity);
            return _mapper.Map<LeadDto>(entity);
        }

        public async Task<LeadDto?> UpdateLeadAsync(int leadId, UpdateLeadDto dto)
        {
            var existing = await _leadRepository.GetByIdAsync(leadId);
            if (existing == null) return null;

            _mapper.Map(dto, existing);
            await _leadRepository.UpdateAsync(existing);
            return _mapper.Map<LeadDto>(existing);
        }

        public async Task<bool> DeleteLeadAsync(int leadId)
        {
            var existing = await _leadRepository.GetByIdAsync(leadId);
            if (existing == null) return false;

            await _leadRepository.DeleteAsync(existing);
            return true;
        }
    }
}
