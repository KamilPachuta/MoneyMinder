using FluentValidation;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.SavingsPortfolios.Validators;

public sealed class CreateSavingsPortfolioValidator : AbstractValidator<CreateSavingsPortfolioRequest>
{
    public CreateSavingsPortfolioValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(40);
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
        
        RuleFor(x => x.PlannedAmount)
            .NotEmpty()
            .GreaterThan(0);
            //.WithMessage("Planned amount must be greater than 0.");
    }
}