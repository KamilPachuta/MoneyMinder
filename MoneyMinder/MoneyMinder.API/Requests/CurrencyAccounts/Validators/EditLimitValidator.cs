using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class EditLimitValidator : AbstractValidator<EditLimitRequest>
{
    public EditLimitValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.Limit.Category)
            .IsInEnum();
        
        RuleFor(x => x.Limit.Amount)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        
    }
}