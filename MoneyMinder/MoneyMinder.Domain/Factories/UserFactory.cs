using MoneyMinder.Domain.Factories.Interfaces;
using MoneyMinder.Domain.Users;
using MoneyMinder.Domain.Users.Entities;
using MoneyMinder.Domain.Users.Enums;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.Factories;

public class UserFactory : IUserFactory
{
    public User Create(Guid id, UserName name, UserPhoneNumber phoneNumber, UserBrithDate birthDate, Gender gender,
        Address address)
        => new(id, name, phoneNumber, birthDate, gender, address);
}