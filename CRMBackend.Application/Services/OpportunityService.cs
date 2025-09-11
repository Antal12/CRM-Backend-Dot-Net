using AutoMapper;
using CRM.Application.Dtos.Opportunity;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class OpportunityService : IOpportunityService
    {
        private readonly IOpportunityRepository _repository;
        private readonly IMapper _mapper;

        public OpportunityService(IOpportunityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // 🔹 CRUD Methods
        public async Task<IEnumerable<OpportunityDto>> GetAllAsync()
        {
            var opportunities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OpportunityDto>>(opportunities);
        }

        public async Task<OpportunityDto?> GetByIdAsync(int id)
        {
            var opportunity = await _repository.GetByIdAsync(id);
            if (opportunity == null) return null;

            return _mapper.Map<OpportunityDto>(opportunity);
        }

        public async Task<OpportunityDto> CreateAsync(CreateOpportunityDto dto)
        {
            var opportunity = _mapper.Map<Opportunity>(dto);
            await _repository.AddAsync(opportunity);

            return _mapper.Map<OpportunityDto>(opportunity);
        }

        public async Task<bool> UpdateAsync(int id, UpdateOpportunityDto dto)
        {
            var opportunity = await _repository.GetByIdAsync(id);
            if (opportunity == null) return false;

            _mapper.Map(dto, opportunity);
            await _repository.UpdateAsync(opportunity);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var opportunity = await _repository.GetByIdAsync(id);
            if (opportunity == null) return false;

            await _repository.DeleteAsync(opportunity);
            return true;
        }

        // 🔹 Custom Queries
        public async Task<IEnumerable<OpportunityDto>> GetByStageAsync(OpportunityStage stage)
        {
            var opportunities = await _repository.GetOpportunitiesByStageAsync(stage);
            return _mapper.Map<IEnumerable<OpportunityDto>>(opportunities);
        }

        public async Task<IEnumerable<OpportunityDto>> GetByCustomerIdAsync(int customerId)
        {
            var opportunities = await _repository.GetOpportunitiesByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<OpportunityDto>>(opportunities);
        }

        public async Task<IEnumerable<OpportunityDto>> GetByOwnerAsync(int ownerUserId)
        {
            var opportunities = await _repository.GetOpportunitiesByOwnerAsync(ownerUserId);
            return _mapper.Map<IEnumerable<OpportunityDto>>(opportunities);
        }
    }
}
