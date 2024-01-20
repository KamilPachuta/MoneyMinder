using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.Savings.Exceptons;

internal sealed class PositiveAmountException : MoneyMinderException
{
    public Amount Amount { get; set; }

    public PositiveAmountException(Amount amount)
        : base($"Amount: '{amount}' cannot be positive.")
        => Amount = amount;
    
    
    
}