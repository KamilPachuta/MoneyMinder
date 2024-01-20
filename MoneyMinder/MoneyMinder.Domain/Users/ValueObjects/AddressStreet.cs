using MoneyMinder.Domain.Users.Exceptions;

namespace MoneyMinder.Domain.Users.ValueObjects;


public record AddressStreet
{
    public string Value { get; set; }

    public AddressStreet(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyAddressStreetException();
        }

        if (value.Length > 255)
        {
            throw new InvalidLengthAddressStreetException(value);
        }
        
        Value = value;
    }
    
    
    
}