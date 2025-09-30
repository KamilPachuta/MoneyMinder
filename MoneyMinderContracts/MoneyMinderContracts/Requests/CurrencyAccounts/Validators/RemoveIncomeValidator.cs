using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public sealed class RemoveIncomeValidator : AbstractValidator<RemoveIncomeRequest>
{
    public RemoveIncomeValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.IncomeId)
            .NotEmpty();
    }
}