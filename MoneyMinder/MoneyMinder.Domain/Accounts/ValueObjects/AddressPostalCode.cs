using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

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
    
    
    public static implicit operator string(AddressPostalCode value)
        => value.Value; 

    public static implicit operator AddressPostalCode(string value)
        => new(value);
}