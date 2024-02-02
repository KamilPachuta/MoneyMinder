using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

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