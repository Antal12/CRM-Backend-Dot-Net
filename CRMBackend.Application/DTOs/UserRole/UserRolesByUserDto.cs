using System.Collections.Generic;

namespace CRM.Application.Dtos.UserRole
{
    public class UserRolesByUserDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new List<string>();
    }
}
