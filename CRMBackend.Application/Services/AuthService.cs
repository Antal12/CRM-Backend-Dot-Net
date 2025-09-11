using AutoMapper;
using CRM.Application.Dtos.Auth;
using CRM.Application.Services.Interfaces;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IJwtService jwtService, IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var user = await _userRepository.ValidateUserAsync(dto.Email, dto.Password);
            if (user == null) return null;

            var roles = await _userRepository.GetUserRolesAsync(user.UserId);
            var token = _jwtService.GenerateJwtToken(user, roles);

            return new LoginResponseDto
            {
                Token = token,
                UserName = user.UserName,
                Email = user.Email,
                Roles = new List<string>(System.Linq.Enumerable.Select(roles, r => r.RoleName))
            };
        }

        public async Task<AuthUserDto> RegisterAsync(RegisterRequestDto dto, int roleId)
        {
            var user = _mapper.Map<User>(dto);

            // Hash password
            (user.PasswordHash, user.PasswordSalt) = CreatePasswordHash(dto.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            // assign default role
            await _userRepository.AssignRoleAsync(user.UserId, roleId);

            var mapped = _mapper.Map<AuthUserDto>(user);
            mapped.Roles = new List<string> { "User" }; // default role
            return mapped;
        }

        private static (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return (hash, salt);
        }
    }
}
