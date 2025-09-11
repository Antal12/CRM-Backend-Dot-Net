using CRM.Application.Dtos.Customer;
using CRM.Application.Dtos.Lead;
using CRM.Application.Dtos.Opportunity;
using CRM.Application.Dtos.Quote;
using CRM.Application.Dtos.Invoice;
using FluentValidation;
using System.Collections.Generic;

namespace CRM.Application.Validators
{
    public class CustomerWithDetailsDtoValidator : AbstractValidator<CustomerWithDetailsDto>
    {
        public CustomerWithDetailsDtoValidator()
        {
            // CustomerId must be greater than 0
            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Customer ID must be greater than 0.");

            // Name is required and max length
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Customer name is required.")
                .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

            // Email is required, valid format, and max length
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

            // AssignedToUserName is required and max length
            RuleFor(x => x.AssignedToUserName)
                .NotEmpty().WithMessage("Assigned user name is required.")
                .MaximumLength(100).WithMessage("Assigned user name cannot exceed 100 characters.");

            // Collections should not be null
            RuleFor(x => x.Leads)
                .NotNull().WithMessage("Leads collection cannot be null.");

            RuleFor(x => x.Opportunities)
                .NotNull().WithMessage("Opportunities collection cannot be null.");

            RuleFor(x => x.Quotes)
                .NotNull().WithMessage("Quotes collection cannot be null.");

            RuleFor(x => x.Invoices)
                .NotNull().WithMessage("Invoices collection cannot be null.");

            // Optional: Validate each item in the collections if their validators exist
          
        }
    }
}
