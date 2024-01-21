using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;


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
    
    public static implicit operator string(AddressStreet value)
        => value.Value; 

    public static implicit operator AddressStreet(string value)
        => new(value);
    
}