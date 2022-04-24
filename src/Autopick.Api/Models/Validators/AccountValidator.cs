using Autopick.Api.Models;
using FluentValidation;

namespace Autopick.Api.Models.Validators
{
    public class AccountValidator : AbstractValidator<AccountModel>
    {
        public AccountValidator()
        {
            RuleFor(a => a.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email must be valid");
        }
    }
}
