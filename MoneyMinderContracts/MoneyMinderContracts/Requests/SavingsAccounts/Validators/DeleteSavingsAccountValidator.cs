using FluentValidation;

namespace MoneyMinderContracts.Requests.SavingsAccounts.Validators;

public sealed class DeleteSavingsAccountValidator : AbstractValidator<DeleteSavingsAccountRequest>
{
    public DeleteSavingsAccountValidator()
    {
        RuleFor(x => x.SavingsAccountId)
            .NotEmpty();
    }
}