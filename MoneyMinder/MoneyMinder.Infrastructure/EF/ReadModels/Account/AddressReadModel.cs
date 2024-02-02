namespace MoneyMinder.Infrastructure.EF.ReadModels.Account;

public class AddressReadModel
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }

    public Guid UserId { get; set; }

    public AddressReadModel()
    {
        
    }
    
    public AddressReadModel(Guid id, string country, string city, string postalCode, string street)
    {
        Id = id;
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
}