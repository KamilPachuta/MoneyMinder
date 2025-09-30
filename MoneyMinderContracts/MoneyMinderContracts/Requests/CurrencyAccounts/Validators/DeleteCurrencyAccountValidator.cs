using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public sealed class DeleteCurrencyAccountValidator : AbstractValidator<DeleteCurrencyAccountRequest>
{
    public DeleteCurrencyAccountValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}