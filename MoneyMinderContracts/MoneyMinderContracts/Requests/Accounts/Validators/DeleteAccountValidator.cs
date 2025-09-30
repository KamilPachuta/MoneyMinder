using FluentValidation;

namespace MoneyMinderContracts.Requests.Accounts.Validators;

public sealed class DeleteAccountValidator : AbstractValidator<DeleteAccountRequest>
{
    public DeleteAccountValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(50);
    }
}