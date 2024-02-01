using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AcceptMonthlyIncomeValidator : AbstractValidator<AcceptMonthlyIncomeRequest>
{
    public AcceptMonthlyIncomeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
            
    }
}