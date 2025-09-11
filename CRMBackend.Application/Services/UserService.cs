using AutoMapper;
using CRM.Application.Dtos.User;
using CRM.Application.Services.Interfaces;
using CRM.Application.Interfaces;
using CRM.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Application.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserWithRolesDto?> GetByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserWithRolesDto?>(user);
        }

        public async Task<UserWithRolesDto?> GetByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            return _mapper.Map<UserWithRolesDto?>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto, string password)
        {
            var user = _mapper.Map<User>(dto);

            // Hash password
            (user.PasswordHash, user.PasswordSalt) = CreatePasswordHash(password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateAsync(int userId, UpdateUserDto dto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return;

            _mapper.Map(dto, user);
            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return;

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        public async Task AssignRoleAsync(int userId, int roleId)
        {
            await _userRepository.AssignRoleAsync(userId, roleId);
        }

        // 🔑 Password hashing helper
        private static (byte[] hash, byte[] salt) CreatePasswordHash(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return (hash, salt);
        }
    }
}
