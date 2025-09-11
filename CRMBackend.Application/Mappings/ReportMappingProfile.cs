using AutoMapper;
using CRM.Application.Dtos.Report;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class ReportMappingProfile : Profile
    {
        public ReportMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Report, ReportDto>()
                .ForMember(dest => dest.ReportType, opt => opt.MapFrom(src => src.ReportType.ToString()))
                .ForMember(dest => dest.GeneratedByUserName, opt => opt.MapFrom(src => src.GeneratedByUser.UserName));

            // DTO -> Entity
            CreateMap<CreateReportDto, Report>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateReportDto, Report>();
        }
    }
}
