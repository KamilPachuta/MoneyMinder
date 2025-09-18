using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AddressStreet
{
    public string Street { get; }

    public AddressStreet(string street)
    {
        if (string.IsNullOrWhiteSpace(street))
        {
            throw new EmptyAddressStreetException();
        }

        if (street.Length > 255)
        {
            throw new InvalidLengthAddressStreetException(street);
        }
        
        Street = street;
    }
    
    public static implicit operator string(AddressStreet street)
        => street.Street; 

    public static implicit operator AddressStreet(string street)
        => new(street);
}