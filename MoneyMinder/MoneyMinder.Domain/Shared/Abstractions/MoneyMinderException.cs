namespace MoneyMinder.Domain.Shared.Abstractions;

public abstract class MoneyMinderException(string message) : Exception(message);