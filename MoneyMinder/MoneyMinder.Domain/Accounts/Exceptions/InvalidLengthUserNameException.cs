using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Accounts.Exceptions;

public class InvalidLengthUserNameException : MoneyMinderException
{
    public string FirstName { get; }
    public string LastName { get; }

    public InvalidLengthUserNameException(string firstName, string lastName)
        : base($"FirstName: '{firstName}' and LastName: '{lastName}' are too long.")
    {
        FirstName = firstName;
        LastName = lastName;
    }
}