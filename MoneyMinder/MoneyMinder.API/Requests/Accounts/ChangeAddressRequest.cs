namespace MoneyMinder.API.Requests.Accounts;

public record ChangeAddressRequest(string Country, string City, string PostalCode, string Street);