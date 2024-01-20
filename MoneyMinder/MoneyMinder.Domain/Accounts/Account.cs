using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.Accounts.DomainEvents;
using MoneyMinder.Domain.Accounts.Exceptions;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Domain.Accounts;

public class Account : AggregateRoot
{
    public AccountEmail Email { get; }
    public AccountRole Role { get; }
    public AccountPasswordHash PasswordHash { get; private set; }

    public Account(Guid id, AccountEmail email, AccountRole role, AccountPasswordHash passwordHash)
        : base(id)
    {
        Email = email;
        Role = role;
        PasswordHash = passwordHash;
        
        RaiseDomainEvent(new AccountCreatedDomainEvent(DateTime.UtcNow, this));
    }

    public void ChangePassword(string password, string newPassword, IPasswordHasher<Account> passwordHasher)
    {
        VerifyPassword(password, passwordHasher);

        var newPasswordHash = new AccountPasswordHash(newPassword, this, passwordHasher);
        
        PasswordHash = newPasswordHash;
        
        RaiseDomainEvent(new PasswordChangedDomainEvent(DateTime.UtcNow, this));
    }

    public void VerifyPassword(string password, IPasswordHasher<Account> passwordHasher)
    {
        var result = passwordHasher.VerifyHashedPassword(this, PasswordHash.Value, password);

        if (result is PasswordVerificationResult.Failed)
        {
            throw new LoginFailedException();
        }

        RaiseDomainEvent(new AccountLoggedInDomainEvent(DateTime.UtcNow, this));
    }
}