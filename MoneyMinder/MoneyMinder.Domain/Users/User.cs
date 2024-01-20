using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;
using MoneyMinder.Domain.Savings;
using MoneyMinder.Domain.Users.DomainEvents;
using MoneyMinder.Domain.Users.Entities;
using MoneyMinder.Domain.Users.Enums;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.Users;

public class User : AggregateRoot
{
    public UserName Name { get; protected set; }
    public UserPhoneNumber PhoneNumber { get; protected set; }
    public UserBrithDate BirthDate { get; protected set; }
    public Gender Gender { get; protected set; }
    
    
    private List<CurrencyAccount> _currencyAccounts;
    private List<SavingsPortfolio> _savings;
    
    private Address _address;

    
    private User()
    {
    }
    
    public User(Guid id, UserName name, UserPhoneNumber phoneNumber, UserBrithDate birthDate, Gender gender, Address address)
        : base(id)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        Gender = gender;
        _address = address;


        RaiseDomainEvent(new UserCreatedDomainEvent(DateTime.UtcNow, this));
    }
    
    
    public void ChangeName(UserName name)
    {
        var oldName = Name;

        Name = name;
        
        RaiseDomainEvent(new UserNameChangedDomainEvent(oldName, name, this));
    }
    
    public void ChangePhoneNumber(UserPhoneNumber phoneNumber)
    {
        var oldPhoneNumber = PhoneNumber;

        PhoneNumber = phoneNumber;
        
        RaiseDomainEvent(new UserPhoneNumberChangedDomainEvent(oldPhoneNumber, phoneNumber, this));
    }

    public void ChangeAddress(Address address)
    {
        var oldAddress = _address;

        _address = address;
        
        RaiseDomainEvent(new UserAddressChangedDomainEvent(oldAddress, address, this));
    }
    

}