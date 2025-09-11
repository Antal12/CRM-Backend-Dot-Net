using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRole>> GetAllAsync();
        Task<UserRole?> GetByIdsAsync(int userId, int roleId);
        Task AssignRoleAsync(int userId, int roleId);
        Task RemoveRoleAsync(int userId, int roleId);
        Task<IEnumerable<Role>> GetRolesByUserIdAsync(int userId);
        Task<IEnumerable<User>> GetUsersByRoleIdAsync(int roleId);
        Task SaveChangesAsync();
    }
}
