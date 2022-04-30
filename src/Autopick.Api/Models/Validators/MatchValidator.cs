using FluentValidation;

namespace Autopick.Api.Models.Validators
{
    public class MatchValidator : AbstractValidator<MatchModel>
    {
        public MatchValidator()
        {
            RuleFor(a => a.ModalityId).NotEmpty().WithMessage("Modality is required");
            RuleFor(a => a.Date).NotNull().WithMessage("Date cannot be null");
            RuleFor(a => a.GroupId).NotEmpty().WithMessage("Group is required");
        }
    }
}
