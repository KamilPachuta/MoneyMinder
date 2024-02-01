using FluentValidation;

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
    }
}