using FluentValidation;

namespace Autopick.Api.Models.Validators
{
    public class GroupValidator : AbstractValidator<GroupModel>
    {
        public GroupValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(a => a.Name).MaximumLength(50).WithMessage("Name must be a maximum of 50 characters");
            RuleFor(a => a.AccountId).NotEmpty().WithMessage("Account is required");
        }
    }
}
