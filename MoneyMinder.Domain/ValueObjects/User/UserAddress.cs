using System.Text.RegularExpressions;
using MoneyMinder.Domain.Exceptions;

namespace MoneyMinder.Domain.ValueObjects.User;

public record UserAddress
{
    private Regex universalPostalCodeRegex = new(@"^[a-z0-9][a-z0-9\- ]{0,10}[a-z0-9]$");
    // private Regex polandPostalCodeRegex = new(@"^\d{2}-\d{3}$");
    private Regex houseNumberRegex = new(@"^\d{1,4}[A-Z]$");
    
    public string Street { get; }
    public string PostalCode { get; }
    public string HouseNumber { get; }
    public uint? ApartmentNumber { get; }

    public UserAddress(string street, string postalCode, string houseNumber)
    {
        if (string.IsNullOrWhiteSpace(street) || string.IsNullOrWhiteSpace(postalCode) ||
            string.IsNullOrWhiteSpace(houseNumber))
        {
            throw new EmptyUserAddressException();
        }

        if (!universalPostalCodeRegex.IsMatch(postalCode) || !houseNumberRegex.IsMatch(houseNumber))
        {
            throw new InvalidUserAddressException(street, postalCode, houseNumber);
        }

        // if (polandPostalCodeRegex.IsMatch(postalCode))
        // {
        //     //logika jeśli adres z polski
        // }
        
        Street = street;
        PostalCode = postalCode;
        HouseNumber = houseNumber;
    }
    
    public UserAddress(string street, string postalCode, string houseNumber, uint? apartmentNumber) : this(street, postalCode, houseNumber)
    {
        ApartmentNumber = apartmentNumber;
    }

    public static UserAddress Create(string value)
    {
        var splittedValue = value.Split(',');
        if (splittedValue.Length == 3)
        {
            return new(splittedValue[0], splittedValue[1], splittedValue[2]);
        }

        if (splittedValue.Length == 4)
        {
            return new(splittedValue[0], splittedValue[1], splittedValue[2], uint.Parse(splittedValue[2]));
        }

        throw new CastingUserAddressException(value);
    }
    
}