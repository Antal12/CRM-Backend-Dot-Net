using CRM.Application.Dtos.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserWithRolesDto?> GetByIdAsync(int userId);
        Task<UserWithRolesDto?> GetByEmailAsync(string email);
        Task<UserDto> CreateAsync(CreateUserDto dto, string password);
        Task UpdateAsync(int userId, UpdateUserDto dto);
        Task DeleteAsync(int userId);
        Task AssignRoleAsync(int userId, int roleId);
    }
}
