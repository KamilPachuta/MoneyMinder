using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class IncomeNotFoundException : MoneyMinderException
{    
    public IncomeNotFoundException(Transaction transaction)
        : base($"Income not found: {transaction}")
    {
    }
}