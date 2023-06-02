namespace MoneyMinder.Domain.Exceptions;

public class EmptyUserNameException : Exception
{
    public EmptyUserNameException() : base("User name cannot be empty.")
    {
    }
}