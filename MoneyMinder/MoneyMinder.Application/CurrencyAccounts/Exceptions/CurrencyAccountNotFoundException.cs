using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class CurrencyAccountNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public CurrencyAccountNotFoundException(Guid id)
        : base($"Currency account with ID: '{id}' not found.")
    {
        Id = id;
    }
}