using CRM.Application.Dtos.Role;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class RoleDtoValidator : AbstractValidator<RoleDto>
    {
        public RoleDtoValidator()
        {
            // ✅ RoleId must be a positive number
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than zero.");

            // ✅ RoleName rules
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Role name is required.")
                .MinimumLength(3).WithMessage("Role name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.");
        }
    }
}
