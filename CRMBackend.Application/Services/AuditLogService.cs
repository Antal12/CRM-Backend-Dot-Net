using AutoMapper;
using CRM.Application.Dtos.AuditLog;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IAuditLogRepository _repository;
        private readonly IMapper _mapper;

        public AuditLogService(IAuditLogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AuditLogDto> CreateAsync(CreateAuditLogDto dto)
        {
            var entity = _mapper.Map<AuditLog>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<AuditLogDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<AuditLogDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AuditLogDto>>(entities);
        }

        public async Task<AuditLogDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<AuditLogDto>(entity);
        }

        public async Task<IEnumerable<AuditLogDto>> GetLogsByEntityAsync(string entityName)
        {
            var entities = await _repository.GetLogsByEntityAsync(entityName);
            return _mapper.Map<IEnumerable<AuditLogDto>>(entities);
        }

        public async Task<IEnumerable<AuditLogDto>> GetLogsByUserIdAsync(int userId)
        {
            var entities = await _repository.GetLogsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<AuditLogDto>>(entities);
        }

        public async Task<bool> UpdateAsync(int id, UpdateAuditLogDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }
    }
}
