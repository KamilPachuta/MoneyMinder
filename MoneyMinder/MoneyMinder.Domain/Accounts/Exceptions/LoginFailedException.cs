using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class LoginFailedException : MoneyMinderException
{
    public LoginFailedException()
        : base("Login failed.")
    {
        
    }
}