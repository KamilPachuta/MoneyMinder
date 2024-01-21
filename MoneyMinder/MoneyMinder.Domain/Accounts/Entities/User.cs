using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Primitives;

namespace MoneyMinder.Domain.Accounts.Entities;

public class User : Entity
{
    public UserName Name { get; protected set; }
    public UserPhoneNumber PhoneNumber { get; protected set; }
    public UserBrithDate BirthDate { get; }
    public Gender Gender { get; }


    //private List<CurrencyAccount> _currencyAccounts;
    //private List<SavingsPortfolio> _savings;

    public Address Address{ get; private set; }

    
    private User()
    {
    }
    
    internal User(Guid id, UserName name, UserPhoneNumber phoneNumber, UserBrithDate birthDate, Gender gender, Address address)
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