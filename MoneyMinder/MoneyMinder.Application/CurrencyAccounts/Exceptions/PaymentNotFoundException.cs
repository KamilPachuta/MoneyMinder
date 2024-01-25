using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;


internal sealed class PaymentNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public PaymentNotFoundException(Guid id)
        : base($"Payment with id: '{id}' not found.")
    {
        Id = id;
    }
}