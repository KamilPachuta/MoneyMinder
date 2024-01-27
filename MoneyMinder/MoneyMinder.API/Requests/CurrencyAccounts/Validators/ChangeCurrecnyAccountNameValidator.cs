using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class ChangeCurrecnyAccountNameValidator : AbstractValidator<ChangeCurrecnyAccountNameRequest>
{
    public ChangeCurrecnyAccountNameValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
    }
}