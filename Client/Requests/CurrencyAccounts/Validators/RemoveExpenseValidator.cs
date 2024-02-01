using Client.Models.Enums;
using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class RemoveExpenseValidator : AbstractValidator<RemoveExpenseRequest>
{
    public RemoveExpenseValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Category)
            .Must(value => Enum.IsDefined(typeof(Category), value))
            .WithMessage("Invalid value for the Category field.");
    }
}