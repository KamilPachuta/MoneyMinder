using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsAccounts.Validators;

public sealed class CreateSavingsAccountValidator : AbstractValidator<CreateSavingsAccountRequest>
{
    public CreateSavingsAccountValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(40);

        RuleFor(x => x.Currency)
            .IsInEnum();
        
        RuleFor(x => x.PlannedAmount)
            .NotEmpty()
            .GreaterThan(0);
    }
}