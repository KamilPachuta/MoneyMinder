using Microsoft.AspNetCore.Identity;
using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Accounts.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

public interface IAccountFactory
{
    Account CreateUser(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher, 
        UserName name, UserPhoneNumber phoneNumber, UserBirthDate birthDate, UserGender gender, 
        AddressCountry country, AddressCity city, AddressPostalCode postalCode, AddressStreet street);

    Account CreateAdmin(AccountEmail email, string password, IPasswordHasher<Account> passwordHasher);
}