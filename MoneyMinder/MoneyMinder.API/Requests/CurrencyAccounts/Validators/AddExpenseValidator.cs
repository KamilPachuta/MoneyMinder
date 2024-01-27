using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AddExpenseValidator : AbstractValidator<AddExpenseRequest>
{
    public AddExpenseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Category)
            .Must(value => Enum.IsDefined(typeof(Category), value))
            .WithMessage("Invalid value for the Category field.");
        
        RuleFor(x => x.ExpenseAmount)
            .NotEmpty()
            .GreaterThan(0);
    }
}