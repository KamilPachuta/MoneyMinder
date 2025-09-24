using MoneyMinder.Domain.Accounts.Enums;

namespace MoneyMinder.API.Requests.Accounts;

public record CreateUserRequest(string Email, string Password, string FirstName, string LastName, 
    string PhoneCode, string PhoneNumber, DateTime BirthDate, Gender Gender, string Country, string City, string PostalCode, string Street);