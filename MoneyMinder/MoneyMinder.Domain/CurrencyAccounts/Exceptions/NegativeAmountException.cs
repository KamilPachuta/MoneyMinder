using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class NegativeAmountException : MoneyMinderException
{
    public decimal Amount { get; set; }

    public NegativeAmountException(decimal amount)
        : base($"Amount: '{amount}' is negative.")
    {
        Amount = amount;
    }
    
    
}