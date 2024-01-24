using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.Accounts.Exceptions;

internal sealed class AccountNotFoundByEmailException : MoneyMinderException
{
    public string Email { get; }


    public AccountNotFoundByEmailException(string email)
        : base($"Account with emial: '{email}' not found.")
        => Email = email;
    

}