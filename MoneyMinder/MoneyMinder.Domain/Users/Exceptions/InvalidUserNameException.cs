using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class InvalidUserNameException : MoneyMinderException
{
    public string Value { get; set; }

    public InvalidUserNameException(string value)
        : base($"Value: '{value}' is incorrect.")
        => Value = value;

}