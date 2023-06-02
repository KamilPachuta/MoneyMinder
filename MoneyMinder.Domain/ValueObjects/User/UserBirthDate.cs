using MoneyMinder.Domain.Exceptions;

namespace MoneyMinder.Domain.ValueObjects.User;

public record UserBirthDate
{
    public DateTime Value { get; }

    public UserBirthDate(DateTime value)
    {
        if (value >= DateTime.Now)
        {
            throw new InvalidUserBirthDateException(value);
        }
        
        Value = value;
    }
    
    public static implicit operator DateTime(UserBirthDate birthDate)
        => birthDate.Value;

    public static implicit operator UserBirthDate(DateTime birthDate)
        => new(birthDate);
}