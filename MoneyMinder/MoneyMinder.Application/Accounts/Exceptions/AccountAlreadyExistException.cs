using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Application.Accounts.Exceptions;

internal sealed class AccountAlreadyExistException : MoneyMinderException
{
    public AccountEmail Email { get; }
    
    public AccountAlreadyExistException(AccountEmail email)
        : base($"Account asignet to email: '{email}' already exist.")
    {
    }
}