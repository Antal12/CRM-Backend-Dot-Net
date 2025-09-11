using AutoMapper;
using CRM.Application.Dtos.Role;
using CRM.Application.Interfaces;
using CRM.Application.Services.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        // Get all roles
        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        // Get role by Id (with assigned users)
        public async Task<RoleWithUsersDto?> GetByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            return role == null ? null : _mapper.Map<RoleWithUsersDto>(role);
        }

        // Create a new role
        public async Task<RoleDto> CreateAsync(CreateRoleDto dto)
        {
            var role = _mapper.Map<Role>(dto);
            await _roleRepository.AddAsync(role);
            await _roleRepository.SaveChangesAsync();
            return _mapper.Map<RoleDto>(role);
        }

        // Update existing role
        public async Task UpdateAsync(int roleId, UpdateRoleDto dto)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null) throw new KeyNotFoundException("Role not found");

            _mapper.Map(dto, role); // map updated properties
            _roleRepository.Update(role);
            await _roleRepository.SaveChangesAsync();
        }

        // Delete a role
        public async Task DeleteAsync(int roleId)
        {
            var role = await _roleRepository.GetByIdAsync(roleId);
            if (role == null) throw new KeyNotFoundException("Role not found");

            _roleRepository.Delete(role);
            await _roleRepository.SaveChangesAsync();
        }
    }
}
