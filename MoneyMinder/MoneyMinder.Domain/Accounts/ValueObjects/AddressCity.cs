using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AddressCity
{
    public string City { get; }
    
    public AddressCity(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new EmptyAddressCityException();
        }

        if (city.Length > 255)
        {
            throw new InvalidLengthAddressCityException(city);
        }
        
        City = city;
    }
    
    public static implicit operator string(AddressCity city)
        => city.City; 

    public static implicit operator AddressCity(string city)
        => new(city);
}