using AutoMapper;
using CRM.Application.Dtos.UserRole;
using CRM.Domain.Entities;
using System.Linq;

namespace CRM.Application.Mappings
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            // Entity -> DTO
            CreateMap<UserRole, UserRoleDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<UserRole, UserRolesByUserDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.UserRoles.Select(ur => ur.Role.RoleName)));

            CreateMap<UserRole, UsersByRoleDto>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName))
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.Role.UserRoles.Select(ur => ur.User.UserName)));

            // DTO -> Entity
            CreateMap<AssignRoleDto, UserRole>();
            CreateMap<RemoveRoleDto, UserRole>();
        }
    }
}
