using System.Text.RegularExpressions;
using MoneyMinder.Domain.Exceptions;

namespace MoneyMinder.Domain.ValueObjects.User;

public record UserEmail
{
    private Regex emailRegex = new(@"^[\w\-\.]+@([\w-]+\.)+[\w-]{2,}$");
    
    public string Value { get; }

    public UserEmail(string value)
    {
        if (value is null)
        {
            throw new EmptyUserEmailException();
        }

        if (!emailRegex.IsMatch(value))
        {
            throw new InvalidUserEmailException(value);
        }

        Value = value;
    }

    public static implicit operator string(UserEmail login)
        => login.Value;

    public static implicit operator UserEmail(string login)
        => new(login);
}