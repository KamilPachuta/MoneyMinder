using MoneyMinder.Domain.Users.Exceptions;

namespace MoneyMinder.Domain.Users.ValueObjects;

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
    
    
    
}