using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;


internal sealed class EmptyAddressPostalCodeException : MoneyMinderException
{
    public EmptyAddressPostalCodeException()
        : base("AddressPostalCode cannot be empty.")
    {
    }
}