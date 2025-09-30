using FluentValidation;

namespace MoneyMinderContracts.Requests.Accounts.Validators;

public sealed class LoginAccountValidator : AbstractValidator<LoginAccountRequest>
{
    public LoginAccountValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(50);
    }
}