using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class MonthlyTransactionNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public MonthlyTransactionNotFoundException(Guid id)
        : base($"Transaction with id: '{id}' not found.")
    {
        Id = id;
    }
}