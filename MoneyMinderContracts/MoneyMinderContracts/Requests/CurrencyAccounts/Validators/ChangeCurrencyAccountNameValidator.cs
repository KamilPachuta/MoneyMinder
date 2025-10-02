using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public sealed class ChangeCurrencyAccountNameValidator : AbstractValidator<ChangeCurrencyAccountNameRequest>
{
    public ChangeCurrencyAccountNameValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
    }
}