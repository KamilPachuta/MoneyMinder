using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyUserException : MoneyMinderException
{

    public EmptyUserException()
        : base("User cannot be null.")
    {
    }
}