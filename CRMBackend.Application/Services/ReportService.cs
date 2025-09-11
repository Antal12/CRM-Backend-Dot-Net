using AutoMapper;
using CRM.Application.Dtos.Report;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using CRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ReportDto> CreateAsync(CreateReportDto dto)
        {
            var entity = _mapper.Map<Report>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<ReportDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<ReportDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReportDto>>(entities);
        }

        public async Task<ReportDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<ReportDto>(entity);
        }

        public async Task<IEnumerable<ReportDto>> GetReportsByTypeAsync(string reportType)
        {
            if (!Enum.TryParse<ReportType>(reportType, out var type)) return Enumerable.Empty<ReportDto>();
            var entities = await _repository.GetReportsByTypeAsync(type);
            return _mapper.Map<IEnumerable<ReportDto>>(entities);
        }

        public async Task<IEnumerable<ReportDto>> GetReportsByUserAsync(int userId)
        {
            var entities = await _repository.GetReportsByUserAsync(userId);
            return _mapper.Map<IEnumerable<ReportDto>>(entities);
        }

        public async Task<bool> UpdateAsync(int id, UpdateReportDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }
    }
}
