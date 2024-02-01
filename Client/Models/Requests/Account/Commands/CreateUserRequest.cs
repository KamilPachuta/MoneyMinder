using Client.Models.Enums;

namespace Client.Models.Requests.Account.Commands;


public class CreateUserRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneCode { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }

    public CreateUserRequest()
    {
        
    }
    
    public CreateUserRequest(string email, string password, string firstName, string lastName, string phoneCode, string phoneNumber, DateTime birthDate, Gender gender, string country, string city, string postalCode, string street)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        PhoneCode = phoneCode;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        Gender = gender;
        Country = country;
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
    
    
    
}
