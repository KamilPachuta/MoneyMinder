using FluentValidation;

namespace MoneyMinderContracts.Requests.CurrencyAccounts.Validators;


public sealed class ConvertCurrencyValidator : AbstractValidator<ConvertCurrencyRequest>
{
    public ConvertCurrencyValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();
        
        RuleFor(x => x.Amount)
            .GreaterThan(0);

        RuleFor(x => x.Coefficient)
            .GreaterThan(0);

        RuleFor(x => x.From)
            .IsInEnum();
        
        RuleFor(x => x.To)
            .IsInEnum();
        
    }
}
