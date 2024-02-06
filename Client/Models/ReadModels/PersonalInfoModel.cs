using Client.Models.Enums;

namespace Client.Models.ReadModels;

public record PersonalInfoModel(string Email, string Name, string PhoneNumber, 
    DateTime BirthDate, Gender Gender, string Country, string City, string PostalCode, string Street);
