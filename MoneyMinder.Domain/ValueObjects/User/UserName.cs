using System.Security.AccessControl;
using MoneyMinder.Domain.Exceptions;

namespace MoneyMinder.Domain.ValueObjects.User;

public record UserName
{
    public string FirstName { get; }
    public string LastName { get; }

    public UserName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            throw new EmptyUserNameException();
        }
        
        FirstName = firstName;
        LastName = lastName;
    }
    
    public static UserName Create(string value)
    {
        var splittedValue = value.Split(' ');
        if (splittedValue.Length is not 2 || string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidUserNameException(value);
        }
        return new(splittedValue.First(), splittedValue.Last());
    }

    public override string ToString()
        => $"{FirstName} {LastName}";
}