using AutoMapper;
using CRM.Application.Dtos.UserRole;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;

        public UserRoleService(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRoleRepository = userRoleRepository;
            _mapper = mapper;
        }

        // Get all user-role assignments
        public async Task<IEnumerable<UserRoleDto>> GetAllAsync()
        {
            var userRoles = await _userRoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserRoleDto>>(userRoles);
        }

        // Get all roles assigned to a user
        public async Task<UserRolesByUserDto?> GetRolesByUserAsync(int userId)
        {
            var roles = await _userRoleRepository.GetRolesByUserIdAsync(userId);
            if (roles == null) return null;

            var userRolesDto = new UserRolesByUserDto
            {
                UserId = userId,
                Roles = roles != null ? _mapper.Map<List<string>>(roles) : new List<string>()
            };

            return userRolesDto;
        }

        // Get all users assigned to a role
        public async Task<UsersByRoleDto?> GetUsersByRoleAsync(int roleId)
        {
            var users = await _userRoleRepository.GetUsersByRoleIdAsync(roleId);
            if (users == null) return null;

            var usersByRoleDto = new UsersByRoleDto
            {
                RoleId = roleId,
                Users = users != null ? _mapper.Map<List<string>>(users) : new List<string>()
            };

            return usersByRoleDto;
        }

        // Assign a role to a user
        public async Task AssignRoleAsync(AssignRoleDto dto)
        {
            await _userRoleRepository.AssignRoleAsync(dto.UserId, dto.RoleId);
            await _userRoleRepository.SaveChangesAsync();
        }

        // Remove a role from a user
        public async Task RemoveRoleAsync(RemoveRoleDto dto)
        {
            await _userRoleRepository.RemoveRoleAsync(dto.UserId, dto.RoleId);
            await _userRoleRepository.SaveChangesAsync();
        }
    }
}
