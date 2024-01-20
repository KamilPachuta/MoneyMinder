using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;


internal sealed class InvalidLengthAddressCityException : MoneyMinderException
{
    public string City { get; set; }

    public InvalidLengthAddressCityException(string city)
        : base($"AddressCity: '{city}' is too long.")
        => City = city;
}
