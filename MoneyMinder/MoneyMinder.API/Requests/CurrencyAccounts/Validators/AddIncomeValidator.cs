using FluentValidation;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AddIncomeValidator : AbstractValidator<AddIncomeRequest>
{
    public AddIncomeValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.Currency)
            .IsInEnum();
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .GreaterThan(0);
    }
}