using CRM.Application.Dtos.UserRole;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class UserRoleDtoValidator : AbstractValidator<UserRoleDto>
    {
        public UserRoleDtoValidator()
        {
            // UserId must be greater than 0
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("UserId must be greater than 0.");

            // UserName must not be empty and have a max length
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("UserName is required.")
                .MaximumLength(100).WithMessage("UserName cannot exceed 100 characters.");

            // RoleId must be greater than 0
            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .WithMessage("RoleId must be greater than 0.");

            // RoleName must not be empty and have a max length
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("RoleName is required.")
                .MaximumLength(100).WithMessage("RoleName cannot exceed 100 characters.");
        }
    }
}
