using FluentValidation;

namespace MoneyMinderContracts.Requests.Accounts.Validators;

public sealed class ChangeNameValidator : AbstractValidator<ChangeNameRequest>
{
    public ChangeNameValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(100);
    }
}