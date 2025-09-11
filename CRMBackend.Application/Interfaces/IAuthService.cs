using CRM.Application.Dtos.Auth;
using System.Threading.Tasks;

namespace CRM.Application.Services.Interfaces
{
    public interface IAuthService
    {
        // 🔑 Login user
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto);

        // 🔑 Register user with a default role
        Task<AuthUserDto> RegisterAsync(RegisterRequestDto dto, int roleId);
    }
}
