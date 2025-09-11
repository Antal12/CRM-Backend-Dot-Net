namespace CRM.Application.Dtos.Customer
{
    public class CreateCustomerDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public int AssignedToUserId { get; set; }
    }
}
