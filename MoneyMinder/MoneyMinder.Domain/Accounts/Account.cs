using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts.DomainEvents;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.CurrencyAccounts;
using MoneyMinder.Domain.SavingsAccounts;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.Accounts;

public class Account : AggregateRoot
{
    public AccountEmail Email { get; }
    
    public AccountRole Role { get; }
    
    public AccountPasswordHash PasswordHash { get; private set; }
    
    
    public User? User { get; private set; }
    public List<CurrencyAccount> CurrencyAccounts { get; } = new();
    public List<SavingsAccount> SavingsAccounts { get; } = new();

    
    private Account()
    {
    }

    internal Account(Guid id, AccountEmail email, AccountRole role, string password, IPasswordHasher<Account> passwordHasher)
        : base(id)
    {
        Email = email;
        Role = role;
        PasswordHash = new AccountPasswordHash(password, this, passwordHasher);
        
        RaiseDomainEvent(new AccountCreatedDomainEvent(DateTime.UtcNow, this));
    }
    
    
    public void VerifyPassword(string password, IPasswordHasher<Account> passwordHasher)
    {
        var result = passwordHasher.VerifyHashedPassword(this, PasswordHash.Password, password);

        if (result is PasswordVerificationResult.Failed)
        {
            throw new LoginFailedException();
        }

        RaiseDomainEvent(new AccountLoggedInDomainEvent(DateTime.UtcNow, this));
    }
    
    internal void AssignUser(User user)
    {
        if (user is null)
        {
            throw new EmptyUserException();
        }
    
        User = user;
    }
    
    public void ChangePassword(string password, string newPassword, IPasswordHasher<Account> passwordHasher)
    {
        VerifyPassword(password, passwordHasher);

        var newPasswordHash = new AccountPasswordHash(newPassword, this, passwordHasher);
        
        PasswordHash = newPasswordHash;
        
        RaiseDomainEvent(new PasswordChangedDomainEvent(DateTime.UtcNow, this));
    }
    
    public void ChangeName(UserName name)
    {
        CheckUser();
        
        var oldName = User.ChangeName(name);
        
        RaiseDomainEvent(new UserNameChangedDomainEvent(oldName, name, this));
    }
    
    public void ChangePhoneNumber(UserPhoneNumber phoneNumber)
    {
        CheckUser();

        var oldPhone = User.ChangePhoneNumber(phoneNumber);
        
        RaiseDomainEvent(new UserPhoneNumberChangedDomainEvent(oldPhone, phoneNumber, this));

    }

    public void ChangeAddress(Address address)
    {
        CheckUser();

        var oldAddress = User.ChangeAddress(address);
        
        RaiseDomainEvent(new UserAddressChangedDomainEvent(oldAddress, address, this));
    }

    private void CheckUser()
    {
        if (User is null)
        {
            throw new UserNullableReferenceException();
        }
    }
    
    
}