using MoneyMinderContracts.Models.Enums;
using MoneyMinderContracts.Responses.Interfaces;

namespace MoneyMinderContracts.Responses.Accounts;

public record GetUserDetailsResponse(DateTime CreatedAt, string Email, string Name, string PhoneNumber, 
    DateTime BirthDate, GenderDto Gender, string Country, string City, string PostalCode, string Street) : IResponse;
