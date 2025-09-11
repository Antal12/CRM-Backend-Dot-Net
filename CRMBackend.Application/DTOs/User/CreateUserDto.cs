namespace CRM.Application.Dtos.User
{
    public class CreateUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;  // plain password (will be hashed in repo)
    }
}
