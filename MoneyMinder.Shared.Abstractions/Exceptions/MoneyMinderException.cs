namespace MoneyMinder.Shared.Abstractions.Exceptions;

public abstract class MoneyMinderException : Exception
{
    protected MoneyMinderException(string message) : base(message)
    {
    }
}