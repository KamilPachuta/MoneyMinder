using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsAccounts.Validators;

public sealed class DeleteSavingsAccountValidator : AbstractValidator<DeleteSavingsAccountRequest>
{
    public DeleteSavingsAccountValidator()
    {
        RuleFor(x => x.SavingsAccountId)
            .NotEmpty();
    }
}