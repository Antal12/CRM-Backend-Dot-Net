using System.Collections.Generic;

namespace CRM.Application.Dtos.Auth
{
    public class AuthUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }
}
