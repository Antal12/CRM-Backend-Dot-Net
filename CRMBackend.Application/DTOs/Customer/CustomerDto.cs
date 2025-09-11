namespace CRM.Application.Dtos.Customer
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public int AssignedToUserId { get; set; }
        public string AssignedToUserName { get; set; } = string.Empty;
    }
}
