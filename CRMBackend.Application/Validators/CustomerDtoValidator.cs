using CRM.Application.Dtos.Customer;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class CustomerDtoValidator : AbstractValidator<CustomerDto>
    {
        public CustomerDtoValidator()
        {
            // CustomerId must be greater than 0
            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("CustomerId must be greater than 0.");

            // Name is required and max 100 characters
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

            // Email is required, max 100 characters, and must be valid
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Phone is required, max 20 characters, and basic phone pattern
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .Matches(@"^\+?[0-9\s\-]+$").WithMessage("Invalid phone number format.");

            // AssignedToUserId must be greater than 0
            RuleFor(x => x.AssignedToUserId)
                .GreaterThan(0)
                .WithMessage("Assigned user ID must be greater than 0.");

            // AssignedToUserName is required and max 100 characters
            RuleFor(x => x.AssignedToUserName)
                .NotEmpty().WithMessage("Assigned user name is required.")
                .MaximumLength(100).WithMessage("Assigned user name cannot exceed 100 characters.");
        }
    }
}
