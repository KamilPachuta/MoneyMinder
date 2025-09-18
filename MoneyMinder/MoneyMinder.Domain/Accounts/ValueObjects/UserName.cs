using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

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
        
        if (firstName.Length > 100 || lastName.Length > 100)
        {
            throw new InvalidLengthUserNameException(firstName, lastName);
        }
        
        FirstName = firstName;
        LastName = lastName;
    }
    
    public static UserName Create(string value)
    {
        var splitted = value.Split('-');
        
        if(splitted.Length != 2)
        { 
            throw new InvalidUserNameException(value);
        }
        
        return new(splitted.First(), splitted.Last());
    }

    public override string ToString()
    {
        return $"{FirstName}-{LastName}";
    }
}