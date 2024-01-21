using MoneyMinder.Domain.Accounts.Exceptions;

namespace MoneyMinder.Domain.Accounts.ValueObjects;

public record UserBrithDate
{
    public DateTime Date { get; set; }

    public UserBrithDate(DateTime date)
    {
        if (NotOver18(date))
        {
            throw new InvalidUserBirthDateException(date);
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
    
    public static implicit operator DateTime(UserBrithDate date)
        => date.Date; 

    public static implicit operator UserBrithDate(DateTime date)
        => new(date);
}