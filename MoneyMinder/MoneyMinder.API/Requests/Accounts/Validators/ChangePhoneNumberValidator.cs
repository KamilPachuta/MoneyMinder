using FluentValidation;

namespace MoneyMinder.API.Requests.Accounts.Validators;

public sealed class ChangePhoneNumberValidator : AbstractValidator<ChangePhoneNumberRequest>
{
    public ChangePhoneNumberValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(4);

        RuleFor(x => x.Number)
            .NotEmpty()
            .MinimumLength(4)
            .MaximumLength(11);
    }
}