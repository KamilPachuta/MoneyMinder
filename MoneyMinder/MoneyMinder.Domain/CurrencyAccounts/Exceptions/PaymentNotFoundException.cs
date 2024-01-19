using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class PaymentNotFoundException : MoneyMinderException
{    
    public PaymentNotFoundException(TransactionName name)
        : base($"Payment not found: {name}")
    {
    }
}