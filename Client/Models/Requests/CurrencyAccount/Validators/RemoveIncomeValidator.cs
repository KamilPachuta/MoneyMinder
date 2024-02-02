using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

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