using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Interfaces
{
    public interface IUserRepository
    {
        // 🔹 User CRUD
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int userId);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task SaveChangesAsync();

        // 🔹 Role Management
        Task AssignRoleAsync(int userId, int roleId);
        Task<IEnumerable<Role>> GetUserRolesAsync(int userId);

        // 🔹 Authentication
        Task<User?> ValidateUserAsync(string email, string password);
    }
}
