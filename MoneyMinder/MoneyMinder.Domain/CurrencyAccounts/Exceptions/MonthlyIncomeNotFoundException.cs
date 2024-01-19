using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class MonthlyIncomeNotFoundException : MoneyMinderException
{
    public TransactionName Name { get; }

    public MonthlyIncomeNotFoundException(TransactionName name)
        : base($"Monthly payment named: '{name}' not found.")
    {
        Name = name;
    }
}