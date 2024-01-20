using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class EmptyAddressStreetException : MoneyMinderException
{
    public EmptyAddressStreetException()
        : base("AddressStreet cannot be empty.")
    {
    }
}

