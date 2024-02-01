using Client.Models.Enums;
using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class EditMonthlyPaymentValidator : AbstractValidator<EditMonthlyPaymentRequest>
{
    public EditMonthlyPaymentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.NewName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.NewAmount)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.NewCategory)
            .Must(value => Enum.IsDefined(typeof(Category), value))
            .WithMessage("Invalid value for the Category field.");
    }
}