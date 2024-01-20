using MoneyMinder.Domain.Users.Exceptions;

namespace MoneyMinder.Domain.Users.ValueObjects;

public record AddressPostalCode
{
    public string Value { get; set; }

    public AddressPostalCode(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyAddressPostalCodeException();
        }

        if (value.Length > 255)
        {
            throw new InvalidLengthAddressPostalCodeException(value);
        }
        
        Value = value;
    }
    
    
    
}