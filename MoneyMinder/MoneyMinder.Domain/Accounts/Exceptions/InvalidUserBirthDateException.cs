using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserBirthDateException : MoneyMinderException
{
    public DateTime Value { get;}

    public InvalidUserBirthDateException(DateTime value)
        : base($"Incorrect birth date: '{value}'User has to be over 18 years.")
        => Value = value;
}