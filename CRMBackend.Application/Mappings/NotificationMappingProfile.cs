using AutoMapper;
using CRM.Application.Dtos.Notification;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class NotificationMappingProfile : Profile
    {
        public NotificationMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Notification, NotificationDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            // DTO -> Entity
            CreateMap<CreateNotificationDto, Notification>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateNotificationDto, Notification>();
        }
    }
}
