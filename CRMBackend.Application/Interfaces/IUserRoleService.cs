using CRM.Application.Dtos.UserRole;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IUserRoleService
    {
        Task<IEnumerable<UserRoleDto>> GetAllAsync();
        Task<UserRolesByUserDto?> GetRolesByUserAsync(int userId);
        Task<UsersByRoleDto?> GetUsersByRoleAsync(int roleId);
        Task AssignRoleAsync(AssignRoleDto dto);
        Task RemoveRoleAsync(RemoveRoleDto dto);
    }
}
