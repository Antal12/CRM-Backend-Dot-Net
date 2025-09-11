namespace CRM.Domain.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = string.Empty;

        // 🔗 Many-to-Many with User
        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
