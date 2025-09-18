using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.Accounts.Entities;

public class Address : Entity
{
    public AddressCountry Country { get; }
    public AddressCity City { get; }
    public AddressPostalCode PostalCode { get; }
    public AddressStreet Street { get; }
    
    private Address()
    {
    }
    
    public Address(Guid id, AddressCountry country, AddressCity city, AddressPostalCode postalCode, AddressStreet street)
        : base(id)
    {
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
}