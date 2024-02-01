namespace MoneyMinder.Infrastructure.EF.ReadModels.Account;

public class UserModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }

    public Guid AccountId { get; set; }
    public AddressModel Address { get; set; }

    public UserModel()
    {
        
    }
    
    public UserModel(Guid id, string name, string phoneNumber, DateTime birthDate)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

}