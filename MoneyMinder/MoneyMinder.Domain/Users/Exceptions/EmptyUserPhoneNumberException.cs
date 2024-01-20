using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class EmptyUserPhoneNumberException : MoneyMinderException
{
    public EmptyUserPhoneNumberException()
        : base($"UserPhoneNumber cannot be empty.")
    {
    }
}