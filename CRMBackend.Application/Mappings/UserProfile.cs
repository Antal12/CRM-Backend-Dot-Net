using AutoMapper;
using CRM.Domain.Entities;
using CRM.Application.Dtos.User;
using System.Linq;

namespace CRM.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // User -> UserDto
            CreateMap<User, UserDto>();

            // User -> UserWithRolesDto (maps Role names from UserRoles)
            CreateMap<User, UserWithRolesDto>()
                .ForMember(dest => dest.Roles,
                    opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.RoleName)));

            // CreateUserDto -> User (password hashing will be handled in repository, not here)
            CreateMap<CreateUserDto, User>();

            // UpdateUserDto -> User
            CreateMap<UpdateUserDto, User>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
