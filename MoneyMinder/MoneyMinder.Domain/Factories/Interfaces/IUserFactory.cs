using MoneyMinder.Domain.Users;
using MoneyMinder.Domain.Users.Entities;
using MoneyMinder.Domain.Users.Enums;
using MoneyMinder.Domain.Users.ValueObjects;

namespace MoneyMinder.Domain.Factories.Interfaces;

internal interface IUserFactory
{
    internal User Create(Guid id, UserName name, UserPhoneNumber phoneNumber, UserBrithDate birthDate, Gender gender, Address address);
}