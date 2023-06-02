namespace MoneyMinder.Domain.Exceptions;

public class EmptyUserAddressException : Exception
{
    public EmptyUserAddressException() : base("Address must contains: Street, PostalCode and HouseNumber separated by ', '.")
    {
    }
}