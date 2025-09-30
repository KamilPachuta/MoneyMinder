using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.Accounts;

public record CreateUserRequest(string Email, string Password, string FirstName, string LastName, 
    string PhoneCode, string PhoneNumber, DateTime BirthDate, GenderDto GenderDto, string Country, string City, string PostalCode, string Street);