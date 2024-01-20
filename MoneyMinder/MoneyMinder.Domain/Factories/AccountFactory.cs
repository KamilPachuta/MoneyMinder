using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Users;
using MoneyMinder.Domain.Users.Entities;
using MoneyMinder.Domain.Users.Enums;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.Factories;

internal sealed class AccountFactory : IAccountFactory
{


    public Account CreateUser(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher, UserName name,
        UserPhoneNumber phoneNumber, UserBrithDate birthDate, Gender gender, Address address)
    {
        var accountId = Guid.NewGuid();
        
        var account = new Account(accountId, email, new AccountRole(Role.User), password, passwordHasher);

        var userId = Guid.NewGuid();
        
        var user = new User(userId, name, phoneNumber, birthDate, gender, address);
        
        account.AssignUser(user);
        
        return account;
    }

    public Account CreateAdmin(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher)
    {
        var id = Guid.NewGuid();
        
        var account = new Account(id, email, new AccountRole(Role.Admin), password, passwordHasher);
        
        return account;
    }
    
}