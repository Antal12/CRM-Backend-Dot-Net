using CRM.Application.Dtos.Role;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class RoleWithUsersDtoValidator : AbstractValidator<RoleWithUsersDto>
    {
        public RoleWithUsersDtoValidator()
        {
            // RoleId validation
            RuleFor(x => x.RoleId)
                .GreaterThan(0).WithMessage("RoleId must be greater than 0.");

            // RoleName validation
            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Role name is required.")
                .MaximumLength(50).WithMessage("Role name must not exceed 50 characters.");

            // Users list validation
            RuleForEach(x => x.Users).ChildRules(user =>
            {
                user.RuleFor(u => u)
                    .NotEmpty().WithMessage("User name cannot be empty.")
                    .MaximumLength(100).WithMessage("User name must not exceed 100 characters.");
            });
        }
    }
}
