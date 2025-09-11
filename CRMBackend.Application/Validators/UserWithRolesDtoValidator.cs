using CRM.Application.Dtos.User;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class UserWithRolesDtoValidator : AbstractValidator<UserWithRolesDto>
    {
        public UserWithRolesDtoValidator()
        {
            // ✅ UserId rules
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than zero.");

            // ✅ UserName rules
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters.");

            // ✅ Email rules
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid email address is required.");

            // ✅ Roles rules
            RuleFor(x => x.Roles)
                .NotNull().WithMessage("Roles list cannot be null.")
                .Must(r => r.Count > 0).WithMessage("At least one role must be assigned.");
        }
    }
}
