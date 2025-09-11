using CRM.Application.Dtos.UserRole;
using FluentValidation;

namespace CRM.Application.Validators
{
    public class RemoveRoleDtoValidator : AbstractValidator<RemoveRoleDto>
    {
        public RemoveRoleDtoValidator()
        {
            // UserId must be greater than 0
            RuleFor(x => x.UserId)
                .GreaterThan(0)
                .WithMessage("UserId must be greater than 0.");

            // RoleId must be greater than 0
            RuleFor(x => x.RoleId)
                .GreaterThan(0)
                .WithMessage("RoleId must be greater than 0.");
        }
    }
}
