using MoneyMinder.Shared.Abstractions.Exceptions;

namespace MoneyMinder.Domain.Exceptions;

public class InvalidUserNameException : MoneyMinderException
{
    public string Name { get; }

    public InvalidUserNameException(string name) : base($"User name '{name}' is invalid.")
    {
        Name = name;
    }
}