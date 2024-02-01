using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AcceptMonthlyPaymentValidator : AbstractValidator<AcceptMonthlyPaymentRequest>
{
    public AcceptMonthlyPaymentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .LessThan(0);
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");

    }
}