using MoneyMinder.Domain.Users.Exceptions;

namespace MoneyMinder.Domain.Users.ValueObjects;

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
    
    
}