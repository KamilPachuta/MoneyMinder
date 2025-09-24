using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.Entities;
using MoneyMinder.Domain.Accounts.Enums;
using MoneyMinder.Domain.Accounts.ValueObjects;
using MoneyMinder.Domain.Factories.Interfaces;

namespace MoneyMinder.Domain.Factories;

internal sealed class AccountFactory : IAccountFactory
{
    public Account CreateUser(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher, UserName name,
        UserPhoneNumber phoneNumber, UserBirthDate birthDate, UserGender gender, AddressCountry country, AddressCity city,
        AddressPostalCode postalCode, AddressStreet street)
    {
        var accountId = Guid.NewGuid();
        
        var account = new Account(accountId, email, new AccountRole(Role.User), password, passwordHasher);

        var userId = Guid.NewGuid();

        var addressId = Guid.NewGuid();
        
        var address = new Address(addressId, country, city, postalCode, street);
        
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