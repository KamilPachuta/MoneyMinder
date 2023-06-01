using MoneyMinder.Shared.Abstractions.Exceptions;

namespace MoneyMinder.Domain.Exceptions;

public class EmptyUserLoginException : MoneyMinderException
{
    public EmptyUserLoginException() : base("User login is empty.")
    {
    }
}