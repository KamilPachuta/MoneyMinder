namespace MoneyMinder.Domain.Exceptions;

public class InvalidUserAddressException : Exception
{
    public string Street { get; }
    public string PostalCode { get; }
    public string HouseNumber { get; }

    public InvalidUserAddressException(string street, string postalCode, string houseNumber) : base($"Street: '{street}', PostalCode: '{postalCode}', HouseNumber: '{houseNumber}'. Those information are invalid for address.")
    {
        Street = street;
        PostalCode = postalCode;
        HouseNumber = houseNumber;
    }
}