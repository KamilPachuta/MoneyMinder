using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class RemovePaymentValidator : AbstractValidator<RemovePaymentRequest>
{
    public RemovePaymentValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.PaymentId)
            .NotEmpty();
    }
}