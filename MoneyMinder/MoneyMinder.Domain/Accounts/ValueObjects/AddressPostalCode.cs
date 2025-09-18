using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AddressPostalCode
{
    public string PostalCode { get; }

    public AddressPostalCode(string postalCode)
    {
        if (string.IsNullOrWhiteSpace(postalCode))
        {
            throw new EmptyAddressPostalCodeException();
        }

        if (postalCode.Length > 10)
        {
            throw new InvalidLengthAddressPostalCodeException(postalCode);
        }
        
        PostalCode = postalCode;
    }
    
    
    public static implicit operator string(AddressPostalCode postalCode)
        => postalCode.PostalCode; 

    public static implicit operator AddressPostalCode(string postalCode)
        => new(postalCode);
}