namespace Client.Models.Requests.Account.Commands;

public class ChangeAddressRequest
{
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }

    public ChangeAddressRequest(string country, string city, string postalCode, string street)
    {
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }

    public ChangeAddressRequest()
    {
    }
}
