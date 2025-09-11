using System.Collections.Generic;

namespace CRM.Application.Dtos.UserRole
{
    public class UsersByRoleDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<string> Users { get; set; } = new List<string>();
    }
}
