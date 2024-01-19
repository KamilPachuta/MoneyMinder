using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

//public class InsufficientFundsException(Currency currency) : MoneyMinderException($"Not enough funds to  to process transaction: {transaction}");
public class InsufficientFundsException : MoneyMinderException
{
    public Currency Currency { get; }
    public Amount Amount { get; set; }
    public InsufficientFundsException(Currency currency, Amount amount)
        : base($"Not enough funds to process transaction for: {amount.Value} {currency}")
    {
        Currency = currency;
        Amount = amount;
    }

}
