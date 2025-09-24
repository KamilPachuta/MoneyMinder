using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.Accounts.Entities;

public class User : Entity
{
    public UserName Name { get; private set; }
    public UserPhoneNumber PhoneNumber { get; private set; }
    public UserBirthDate BirthDate { get; }
    public UserGender Gender { get; }
    
    
    public Address Address{ get; private set; }
    
    
    private User()
    {
    }
    
    internal User(Guid id, UserName name, UserPhoneNumber phoneNumber, UserBirthDate birthDate, UserGender gender, Address address)
        : base(id)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        Gender = gender;
        Address = address;
    }
    
    
    internal UserName ChangeName(UserName name)
    {
        var oldName = Name;
        
        Name = name;

        return oldName;
    }
    
    internal UserPhoneNumber ChangePhoneNumber(UserPhoneNumber phoneNumber)
    {
        var oldPhoneNumber = PhoneNumber;
        
        PhoneNumber = phoneNumber;

        return oldPhoneNumber;
    }

    internal Address ChangeAddress(Address address)
    {
        var oldAddress = Address;
        
        Address = address;

        return oldAddress;
    }
}