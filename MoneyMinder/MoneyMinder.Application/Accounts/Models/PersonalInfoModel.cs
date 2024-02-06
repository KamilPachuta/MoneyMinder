using MoneyMinder.Domain.Accounts.Enum;

namespace MoneyMinder.Application.Accounts.Models;

public record PersonalInfoModel(string Email, string Name, string PhoneNumber, 
    DateTime BirthDate, Gender Gender, string Country, string City, string PostalCode, string Street);