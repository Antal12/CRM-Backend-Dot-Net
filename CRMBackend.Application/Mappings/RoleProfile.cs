using AutoMapper;
using CRM.Application.Dtos.Role;
using CRM.Domain.Entities;
using System.Linq;

namespace CRM.Application.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            // Entity -> DTO
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleWithUsersDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.User.UserName)));

            // DTO -> Entity
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();
        }
    }
}
