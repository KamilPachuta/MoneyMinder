using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;

namespace MoneyMinder.Domain.Factories;

internal sealed class AccountFactory : IAccountFactory
{
    public Account CreateUser(Guid id, AccountEmail email, string password,IPasswordHasher<Account> passwordHasher)
    {

        var account = new Account(id, email, new AccountRole(Role.User), password, passwordHasher);

        // var user = _userFactory.Create();
        //
        // account.AssignUser(user);
        //
        
        return account;
    }

    public Account CreateAdmin(Guid id, AccountEmail email, string password, IPasswordHasher<Account> passwordHasher)
    {
        var account = new Account(id, email, new AccountRole(Role.Admin), password, passwordHasher);
        
        return account;
    }
    
}