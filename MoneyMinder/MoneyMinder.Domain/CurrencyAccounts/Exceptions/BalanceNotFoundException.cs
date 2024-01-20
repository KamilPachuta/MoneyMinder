using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class BalanceNotFoundException : MoneyMinderException
{
    public BalanceNotFoundException(Currency currency)
        : base($"Balance not found for currency: {currency}")
    {
    }   
}
