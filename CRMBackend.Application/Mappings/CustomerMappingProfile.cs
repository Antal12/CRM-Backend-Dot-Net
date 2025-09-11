using AutoMapper;
using CRM.Application.Dtos.Customer;
using CRM.Domain.Entities;

namespace CRM.Application.Mappings
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.AssignedToUserName, opt => opt.MapFrom(src => src.AssignedToUser.UserName));

            CreateMap<Customer, CustomerWithDetailsDto>()
                .ForMember(dest => dest.AssignedToUserName, opt => opt.MapFrom(src => src.AssignedToUser.UserName));

            // DTO -> Entity
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>();
        }
    }
}
