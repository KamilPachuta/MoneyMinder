using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AccountPasswordHash
{
    public string Value { get; }

    private AccountPasswordHash()
    {
        
    }

    private AccountPasswordHash(string value)
    {
        Value = value;
    }

    internal AccountPasswordHash(string password, Account account, IPasswordHasher<Account> passwordHasher)
    {
        if (string.IsNullOrWhiteSpace(password))
        {
            throw new EmptyPasswordHashException();
        }

        var passwordHash = passwordHasher.HashPassword(account, password);

        Value = passwordHash;
    }

    public static AccountPasswordHash Create(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash))
        {
            throw new EmptyPasswordHashException();
        }

        var password = new AccountPasswordHash(passwordHash);
        
        return password;
    }

    
    
    
}