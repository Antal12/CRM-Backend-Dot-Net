using CRM.Application.Dtos.Role;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleWithUsersDto?> GetByIdAsync(int roleId);
        Task<RoleDto> CreateAsync(CreateRoleDto dto);
        Task UpdateAsync(int roleId, UpdateRoleDto dto);
        Task DeleteAsync(int roleId);
    }
}
