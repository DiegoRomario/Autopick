using FluentValidation;

namespace Autopick.Api.Models.Validators
{
    public class ModalityValidator : AbstractValidator<ModalityModel>
    {
        public ModalityValidator()
        {
            RuleFor(a => a.Name).NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(a => a.Name).MaximumLength(50).WithMessage("Name must be a maximum of 50 characters");

            RuleFor(a => a.Description).MaximumLength(50).WithMessage("Description must be a maximum of 240 characters");
        }
    }
}
