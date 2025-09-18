using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record UserBirthDate
{
    public DateTime Date { get; }

    public UserBirthDate(DateTime date)
    {
        if (NotOver18(date))
        {
            throw new InvalidUserBirthDateException(date);
        }

        if (date.Kind != DateTimeKind.Utc)
        {
            date = date.ToUniversalTime();
        }

        Date = date;
    }
    
    private bool NotOver18(DateTime date)
    {
        int age = DateTime.Now.Year - date.Year;

        if (DateTime.Now < date.AddYears(age))
        {
            age--;
        }

        return age < 18;
    }
    
    public static implicit operator DateTime(UserBirthDate date)
        => date.Date; 

    public static implicit operator UserBirthDate(DateTime date)
        => new(date);
}