using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class EmptyUserNameException : MoneyMinderException
{
    public EmptyUserNameException()
        : base($"UserName cannot be empty.")
    {
    }
}