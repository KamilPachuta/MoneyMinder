using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class CreateCurrencyAccountValidator : AbstractValidator<CreateCurrencyAccountRequest>
{
    public CreateCurrencyAccountValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
    }
}