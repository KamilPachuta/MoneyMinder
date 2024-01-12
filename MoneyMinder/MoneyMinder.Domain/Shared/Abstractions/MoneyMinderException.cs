namespace MoneyMinder.Domain.Abstractions;

public abstract class MoneyMinderException(string message) : Exception(message);