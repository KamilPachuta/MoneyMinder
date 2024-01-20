using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class InvalidLengthAddressStreetException : MoneyMinderException
{
    public string Street { get; set; }

    public InvalidLengthAddressStreetException(string street)
        : base($"AddressStreet: '{street}' is too long.")
        => Street = street;
}
