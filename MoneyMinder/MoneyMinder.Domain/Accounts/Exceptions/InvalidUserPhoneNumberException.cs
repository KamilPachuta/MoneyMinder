using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidUserPhoneNumberException :  MoneyMinderException
{
    public string Value { get; set; }

    public InvalidUserPhoneNumberException(string value)
        : base($"Value: '{value}' is incorrect format.")
        => Value = value;

}