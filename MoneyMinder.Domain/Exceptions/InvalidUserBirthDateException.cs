namespace MoneyMinder.Domain.Exceptions;

public class InvalidUserBirthDateException : Exception
{
    public InvalidUserBirthDateException(DateTime value) : base($"Date: '{value}' is invalid.")
    {
        
    }
}