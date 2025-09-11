using AutoMapper;
using CRM.Domain.Entities;
using CRM.Application.Dtos.Auth;
using System.Linq;

namespace CRM.Application.Mappings
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            // User -> AuthUserDto
            CreateMap<User, AuthUserDto>()
                .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.RoleName)));

            // RegisterRequestDto -> User
            CreateMap<RegisterRequestDto, User>();
        }
    }
}
