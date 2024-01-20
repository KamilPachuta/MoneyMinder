using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record AccountPasswordHash
{
    public string Value { get; }

    private AccountPasswordHash(string value)
    {
        Value = value;
    }

    public AccountPasswordHash(string password, Account account, IPasswordHasher<Account> passwordHasher)
    {
        if (password is null)
        {
            throw new EmptyPasswordHashException();
        }

        var passwordHash = passwordHasher.HashPassword(account, password);

        Value = passwordHash;
    }

    
    
}