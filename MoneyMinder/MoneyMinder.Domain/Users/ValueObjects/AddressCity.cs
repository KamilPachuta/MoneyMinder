using MoneyMinder.Domain.Users.Exceptions;

namespace MoneyMinder.Domain.Users.ValueObjects;

public record AddressCity
{
    public string Value { get; set; }

    public AddressCity(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyAddressCityException();
        }

        if (value.Length > 255)
        {
            throw new InvalidLengthAddressCityException(value);
        }
        
        Value = value;
    }
    
    
    public static implicit operator string(AddressCity value)
        => value.Value; 

    public static implicit operator AddressCity(string value)
        => new(value);
}