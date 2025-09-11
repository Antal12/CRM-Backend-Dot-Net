using AutoMapper;
using CRM.Application.Dtos.Quote;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class QuoteMappingProfile : Profile
    {
        public QuoteMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Quote, QuoteDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.OpportunityName, opt => opt.MapFrom(src => src.Opportunity.Stage.ToString()))
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            CreateMap<Quote, QuoteWithDetailsDto>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.OpportunityName, opt => opt.MapFrom(src => src.Opportunity.Stage.ToString()))
                .ForMember(dest => dest.CreatedByUserName, opt => opt.MapFrom(src => src.CreatedByUser.UserName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

            // DTO -> Entity
            CreateMap<CreateQuoteDto, Quote>();
            CreateMap<UpdateQuoteDto, Quote>();
        }
    }
}
