using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class IncomeNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public IncomeNotFoundException(Guid id)
        : base($"Income with id: '{id}' not found.")
    {
        Id = id;
    }
}