using CRM.Application.Dtos.Customer;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            // Name is required and has a max length
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

            // Email is required, valid email format, and max length
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Phone is required, max length, and basic phone pattern
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.")
                .Matches(@"^\+?[0-9\s\-]+$").WithMessage("Invalid phone number format.");

            // AssignedToUserId must be greater than 0
            RuleFor(x => x.AssignedToUserId)
                .GreaterThan(0).WithMessage("Assigned user ID must be greater than 0.");
        }
    }
}
