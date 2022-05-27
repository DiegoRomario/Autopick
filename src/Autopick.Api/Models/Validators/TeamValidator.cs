using FluentValidation;

namespace Autopick.Api.Models.Validators
{
    public class TeamValidator : AbstractValidator<TeamModel>
    {
        public TeamValidator()
        {
            RuleFor(a => a.ModalityId).NotEmpty().WithMessage("Modality is required");
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(a => a.Name).MaximumLength(50).WithMessage("Name must be a maximum of 50 characters");
            RuleFor(a => a.Players).NotEmpty().WithMessage("A team must contain at least one player");
        }
    }
}
