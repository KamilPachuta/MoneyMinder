using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AddPaymentValidator : AbstractValidator<AddPaymentRequest>
{
    public AddPaymentValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Date cannot be in the future.")
            .Must(d => d.Year == DateTime.UtcNow.Year && d.Month == DateTime.UtcNow.Month)
            .WithMessage("Date must be in the current month.");

        RuleFor(x => x.Currency)
            .IsInEnum();
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .LessThan(0);

        RuleFor(x => x.Category)
            .IsInEnum();
    }   
}