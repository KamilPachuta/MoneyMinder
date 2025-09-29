using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsAccounts.Validators;

public sealed class ChangeSavingsAccountNameValidator : AbstractValidator<ChangeSavingsAccountNameRequest>
{
    public ChangeSavingsAccountNameValidator()
    {
        RuleFor(x => x.SavingsAccountId)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
    }
}