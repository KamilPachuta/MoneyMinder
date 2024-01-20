using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;


internal sealed class EmptyAddressCityException : MoneyMinderException
{
    public EmptyAddressCityException()
        : base("AddressCity cannot be empty.")
    {
    }
}