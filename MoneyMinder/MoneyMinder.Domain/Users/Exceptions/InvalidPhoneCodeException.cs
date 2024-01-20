using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Users.Exceptions;

internal sealed class InvalidPhoneCodeException : MoneyMinderException
{
    public string Code { get; }

    public InvalidPhoneCodeException(string code)
        : base($"PhoneCode: '{code}' is invalid.")
    {
        Code = code;
    }
}