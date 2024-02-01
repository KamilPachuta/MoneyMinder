namespace MoneyMinder.Infrastructure.EF.ReadModels.Account;

public class AddressModel
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }

    public Guid UserId { get; set; }

    public AddressModel()
    {
        
    }
    
    public AddressModel(Guid id, string country, string city, string postalCode, string street)
    {
        Id = id;
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
}