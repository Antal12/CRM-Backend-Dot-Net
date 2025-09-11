using AutoMapper;
using CRM.Application.Dtos.Opportunity;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class OpportunityMappingProfile : Profile
    {
        public OpportunityMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Opportunity, OpportunityDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.OwnerUser.UserName))
                .ForMember(dest => dest.Stage, opt => opt.MapFrom(src => src.Stage.ToString()));

            CreateMap<Opportunity, OpportunityWithDetailsDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.OwnerUserName, opt => opt.MapFrom(src => src.OwnerUser.UserName))
                .ForMember(dest => dest.Stage, opt => opt.MapFrom(src => src.Stage.ToString()));

            // DTO -> Entity
            CreateMap<CreateOpportunityDto, Opportunity>();
            CreateMap<UpdateOpportunityDto, Opportunity>();
        }
    }
}
