using FluentValidation;

namespace MoneyMinderContracts.Requests.SavingsAccounts.Validators;

public sealed class CreateSavingsAccountValidator : AbstractValidator<CreateSavingsAccountRequest>
{
    public CreateSavingsAccountValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(40);

        RuleFor(x => x.CurrencyDto)
            .IsInEnum();
        
        RuleFor(x => x.PlannedAmount)
            .NotEmpty()
            .GreaterThan(0);
    }
}