using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class EmptyAddressStreetException : MoneyMinderException
{
    public EmptyAddressStreetException()
        : base("AddressStreet cannot be empty.")
    {
    }
}

