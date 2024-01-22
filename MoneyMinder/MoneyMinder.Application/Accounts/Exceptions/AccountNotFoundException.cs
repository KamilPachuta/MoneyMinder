using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.Accounts.Exceptions;

internal sealed class AccountNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public AccountNotFoundException(Guid id)
    : base($"Account with id: '{id}' not found.")
    {
        Id = id;
    }
    
}