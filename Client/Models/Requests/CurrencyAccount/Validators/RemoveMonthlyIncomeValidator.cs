using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class RemoveMonthlyIncomeValidator : AbstractValidator<RemoveMonthlyIncomeRequest>
{
    public RemoveMonthlyIncomeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.MonthlyIncomeName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }
}