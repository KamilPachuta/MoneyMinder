using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class PaymentNotFoundException : MoneyMinderException
{    
    public PaymentNotFoundException(Transaction transaction)
        : base($"Payment not found: {transaction}")
    {
    }
}