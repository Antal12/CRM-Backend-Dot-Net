using CRM.Application.Dtos.UserRole;
using FluentValidation;
using System.Collections.Generic;

namespace CRM.Application.Validators
{
    public class UsersByRoleDtoValidator : AbstractValidator<UsersByRoleDto>
    {
        public UsersByRoleDtoValidator()
        {
            // RoleId must be greater than 0
            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .WithMessage("RoleId must be greater than 0.");

            // RoleName must not be empty and have a max length
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("RoleName is required.")
                .MaximumLength(100).WithMessage("RoleName cannot exceed 100 characters.");

            // Users list must not be null
            RuleFor(x => x.Users)
                .NotNull().WithMessage("Users list cannot be null.")
                .Must(list => list.Count > 0)
                .WithMessage("Users list must contain at least one user.");

            // Optional: each user name should not be empty
            RuleForEach(x => x.Users)
                .NotEmpty().WithMessage("User name cannot be empty.");
        }
    }
}
