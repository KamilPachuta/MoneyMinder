using Client.Models.Enums;
using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class CreateBudgetValidator : AbstractValidator<CreateBudgetRequest>
{
    public CreateBudgetValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.ExpectedIncome)
            .NotEmpty()
            .GreaterThan(0);

        //RuleFor(x => x.Expenses);
        
        RuleFor(x => x.Date)
            .NotEmpty();
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
    }
}