using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AddressCountry
{
    public string Country { get; }
    
    public AddressCountry(string country)
    {
        if (string.IsNullOrWhiteSpace(country))
        {
            throw new EmptyAddressCountryException();
        }

        if (country.Length > 255)
        {
            throw new InvalidLengthAddressCountryException(country);
        }
        
        Country = country;
    }
    
    public static implicit operator string(AddressCountry country)
        => country.Country; 

    public static implicit operator AddressCountry(string country)
        => new(country);
}