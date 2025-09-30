using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;

public sealed class EditLimitValidator : AbstractValidator<EditLimitRequest>
{
    public EditLimitValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.Limit.CategoryDto)
            .IsInEnum();
        
        RuleFor(x => x.Limit.Amount)
            .NotNull()
            .GreaterThanOrEqualTo(0);
        
    }
}