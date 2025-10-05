using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Requests.Accounts;

public class CreateUserRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string PhoneCode { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public GenderDto GenderDto { get; set; }
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;

    public CreateUserRequest()
    {
    }
    
    public CreateUserRequest(
        string email, 
        string password, 
        string firstName, 
        string lastName, 
        string phoneCode, 
        string phoneNumber, 
        DateTime birthDate, 
        GenderDto genderDto, 
        string country, 
        string city, 
        string postalCode, 
        string street)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        PhoneCode = phoneCode;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        GenderDto = genderDto;
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
}
