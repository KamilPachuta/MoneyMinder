using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AddressCountry
{
    public string Value { get; set; }

    public AddressCountry(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyAddressCountryException();
        }

        if (value.Length > 255)
        {
            throw new InvalidLengthAddressCountryException(value);
        }
        
        Value = value;
    }
    
    
    
    public static implicit operator string(AddressCountry value)
        => value.Value; 

    public static implicit operator AddressCountry(string value)
        => new(value);
}