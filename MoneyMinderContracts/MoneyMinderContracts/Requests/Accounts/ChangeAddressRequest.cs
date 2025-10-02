namespace MoneyMinderContracts.Requests.Accounts;

public class ChangeAddressRequest
{
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;

    public ChangeAddressRequest()
    {
    }
    
    public ChangeAddressRequest(string country, string city, string postalCode, string street)
    {
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
}
