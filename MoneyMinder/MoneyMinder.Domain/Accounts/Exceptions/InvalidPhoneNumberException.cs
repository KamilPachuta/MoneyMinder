using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

internal sealed class InvalidPhoneNumberException : MoneyMinderException
{
    public string Number { get; }

    public InvalidPhoneNumberException(string number)
        : base($"PhoneNumber: '{number}' is invalid.")
        => Number = number;
    
}