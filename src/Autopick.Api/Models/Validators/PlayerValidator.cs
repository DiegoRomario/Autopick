using FluentValidation;

namespace Autopick.Api.Models.Validators
{
    public class PlayerValidator : AbstractValidator<PlayerModel>
    {
        public PlayerValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(a => a.BirthDate).NotNull().WithMessage("Birth Date cannot be null");
            RuleFor(a => a.Weight).GreaterThan(0).WithMessage("Weight must be greather than 0");
            RuleFor(a => a.Height).GreaterThan(0).WithMessage("Height must be greather than 0");
        }
    }
}
