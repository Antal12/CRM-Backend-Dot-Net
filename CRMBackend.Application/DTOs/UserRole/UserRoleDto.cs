﻿namespace CRM.Application.Dtos.UserRole
{
    public class UserRoleDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;

        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;
    }
}
