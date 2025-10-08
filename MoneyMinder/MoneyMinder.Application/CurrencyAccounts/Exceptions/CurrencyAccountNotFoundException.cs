using MoneyMinder.Domain.Shared.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

public sealed class CurrencyAccountNotFoundException : MoneyMinderException
{
    public CurrencyAccountNotFoundException(Guid id)
        : base($"Currency Account with ID: '{id}' was not found.") { }

    public CurrencyAccountNotFoundException(string name)
        : base($"Currency Account with name: '{name}' was not found.") { }
}

