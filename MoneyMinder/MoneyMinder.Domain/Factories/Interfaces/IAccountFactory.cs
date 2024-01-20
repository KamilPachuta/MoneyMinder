using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface IAccountFactory
{
    Account CreateUser(Guid id, AccountEmail email, string password,IPasswordHasher<Account> passwordHasher);

    Account CreateAdmin(Guid id, AccountEmail email, string password,IPasswordHasher<Account> passwordHasher);
    
}