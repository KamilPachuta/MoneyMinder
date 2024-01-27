using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AddMonthlyPaymentValidator : AbstractValidator<AddMonthlyPaymentRequest>
{
    public AddMonthlyPaymentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty();
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .LessThan(0);

        RuleFor(x => x.Category)
            .Must(value => Enum.IsDefined(typeof(Category), value))
            .WithMessage("Invalid value for the Category field.");
    }   
}