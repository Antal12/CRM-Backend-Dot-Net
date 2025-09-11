using System.Collections.Generic;

namespace CRM.Application.Dtos.Role
{
    public class RoleWithUsersDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public List<string> Users { get; set; } = new List<string>(); // user names assigned to this role
    }
}
