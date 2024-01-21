using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.ValueObjects;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;

internal sealed class CurrencyAccountAlreadyExistException : MoneyMinderException
{
    public CurrencyAccountName Name { get; }

    public CurrencyAccountAlreadyExistException(CurrencyAccountName name)
        : base($"Currency account with name: '{name}' already exist.")
    {
        Name = name;
    }
}