using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class EditMonthlyIncomeValidator : AbstractValidator<EditMonthlyIncomeRequest>
{
    public EditMonthlyIncomeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.NewAmount)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.NewCurrency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");

    }
}