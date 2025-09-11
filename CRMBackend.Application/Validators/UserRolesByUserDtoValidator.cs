using CRM.Application.Dtos.UserRole;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class UserRolesByUserDtoValidator : AbstractValidator<UserRolesByUserDto>
    {
        public UserRolesByUserDtoValidator()
        {
            // UserId must be greater than 0
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("UserId must be greater than 0.");

            // UserName must not be empty and have a max length
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(100).WithMessage("UserName cannot exceed 100 characters.");

            // Roles list must not be null
            RuleFor(x => x.Roles)
                .NotNull().WithMessage("Roles list cannot be null.")
                .Must(list => list.Count > 0)
                .WithMessage("Roles list must contain at least one role.");

            // Optional: each role name should not be empty
            RuleForEach(x => x.Roles)
                .NotEmpty().WithMessage("Role name cannot be empty.");
        }
    }
}
