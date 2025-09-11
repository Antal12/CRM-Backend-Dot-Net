using AutoMapper;
using CRM.Application.Dtos.AuditLog;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class AuditLogMappingProfile : Profile
    {
        public AuditLogMappingProfile()
        {
            // Entity -> DTO
            CreateMap<AuditLog, AuditLogDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));

            // DTO -> Entity
            CreateMap<CreateAuditLogDto, AuditLog>()
                .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateAuditLogDto, AuditLog>();
        }
    }
}
