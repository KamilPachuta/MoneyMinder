using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class RemoveMonthlyPaymentValidator : AbstractValidator<RemoveMonthlyPaymentRequest>
{
    public RemoveMonthlyPaymentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.MonthlyPaymentName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
    }
}