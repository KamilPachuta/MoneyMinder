using FluentValidation;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class CreateBudgetValidator : AbstractValidator<CreateBudgetRequest>
{
    public CreateBudgetValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();
        
        RuleFor(x => x.Date)
            .NotEmpty()
            .Must(BeInCurrentMonth)
            .WithMessage("Date must be in the current month.");

        RuleFor(x => x.Currency)
            .IsInEnum();
        
        RuleFor(x => x.Limits)
            .NotEmpty()
            .Must(l => l
                .Select(m => m.Category)
                .Distinct()
                .Count() == DefinedCategory.Count())
            .WithMessage("Limits must contain each category exactly once.");
    }
    
    private bool BeInCurrentMonth(DateTime date)
    {
        var now = DateTime.UtcNow;
        return date.Year == now.Year && date.Month == now.Month;
    }
}