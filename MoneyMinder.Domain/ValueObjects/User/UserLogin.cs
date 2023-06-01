using MoneyMinder.Domain.Exceptions;

namespace MoneyMinder.Domain.ValueObjects.User;

public record UserLogin
{
    public string Value { get; }

    public UserLogin(string value)
    {
        if (value is null)
        {
            throw new EmptyUserLoginException();
        }

        Value = value;
    }

    public static implicit operator string(UserLogin login)
        => login.Value;

    public static implicit operator UserLogin(string login)
        => new(login);
}