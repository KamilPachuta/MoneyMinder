using MoneyMinder.Shared.Abstractions.Exceptions;

namespace MoneyMinder.Domain.Exceptions;

public class InvalidUserEmailException : MoneyMinderException
{
    public string Email { get; }

    public InvalidUserEmailException(string email) : base($"Email '{email}' is invalid.")
    {
        Email = email;
    }
}