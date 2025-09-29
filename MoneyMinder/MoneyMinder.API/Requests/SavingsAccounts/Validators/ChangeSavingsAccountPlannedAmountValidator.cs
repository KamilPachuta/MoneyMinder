using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsAccounts.Validators;

public sealed class ChangeSavingsAccountPlannedAmountValidator : AbstractValidator<ChangeSavingsAccountPlannedAmountRequest>
{
    public ChangeSavingsAccountPlannedAmountValidator()
    {
        RuleFor(x => x.SavingsAccountId)
            .NotEmpty();
        
        RuleFor(x => x.PlannedAmount)
            .NotEmpty()
            .GreaterThan(0);
    }
}