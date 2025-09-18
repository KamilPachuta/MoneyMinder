using MoneyMinder.Domain.Accounts.Enum;

namespace MoneyMinder.Infrastructure.EF.ReadModels.Accounts;

public class UserReadModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }

    public AddressReadModel Address { get; set; }

    public UserReadModel()
    {
        
    }
    
    public UserReadModel(Guid id, string name, string phoneNumber, DateTime birthDate)
    {
        Id = id;
        Name = name;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }
}