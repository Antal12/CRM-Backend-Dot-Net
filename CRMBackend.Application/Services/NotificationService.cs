using AutoMapper;
using CRM.Application.Dtos.Notification;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _repository;
        private readonly IMapper _mapper;

        public NotificationService(INotificationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<NotificationDto> CreateAsync(CreateNotificationDto dto)
        {
            var entity = _mapper.Map<Notification>(dto);
            await _repository.AddAsync(entity);
            return _mapper.Map<NotificationDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            await _repository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<NotificationDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<NotificationDto>>(entities);
        }

        public async Task<NotificationDto?> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return entity == null ? null : _mapper.Map<NotificationDto>(entity);
        }

        public async Task<IEnumerable<NotificationDto>> GetNotificationsByUserIdAsync(int userId)
        {
            var entities = await _repository.GetNotificationsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(entities);
        }

        public async Task<IEnumerable<NotificationDto>> GetUnreadNotificationsByUserIdAsync(int userId)
        {
            var entities = await _repository.GetUnreadNotificationsByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<NotificationDto>>(entities);
        }

        public async Task<bool> UpdateAsync(int id, UpdateNotificationDto dto)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            await _repository.UpdateAsync(entity);
            return true;
        }
    }
}
