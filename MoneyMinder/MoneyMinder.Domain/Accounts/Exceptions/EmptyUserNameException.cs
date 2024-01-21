using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyUserNameException : MoneyMinderException
{
    public EmptyUserNameException()
        : base($"UserName cannot be empty.")
    {
    }
}