using AutoMapper;
using CRM.Application.Dtos.Lead;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class LeadMappingProfile : Profile
    {
        public LeadMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Lead, LeadDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Name : string.Empty))
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<Lead, LeadWithDetailsDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer != null ? src.Customer.Name : string.Empty))
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            // DTO -> Entity
            CreateMap<CreateLeadDto, Lead>();
            CreateMap<UpdateLeadDto, Lead>();
        }
    }
}
