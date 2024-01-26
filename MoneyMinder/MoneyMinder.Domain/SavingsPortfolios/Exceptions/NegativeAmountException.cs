using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.SavingsPortfolios.Exceptions;

internal sealed class NegativeAmountException : MoneyMinderException
{
    public Amount Amount { get; set; }

    public NegativeAmountException(Amount amount)
        : base($"Amount: '{amount}' cannot be negative.")
        => Amount = amount;
}