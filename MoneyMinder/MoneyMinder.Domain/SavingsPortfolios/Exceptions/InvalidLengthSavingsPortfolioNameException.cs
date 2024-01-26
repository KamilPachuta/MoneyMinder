using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.SavingsPortfolios.Exceptions;

internal sealed class InvalidLengthSavingsPortfolioNameException : MoneyMinderException
{
    public string Value { get; set; }

    public InvalidLengthSavingsPortfolioNameException(string value)
        : base($"Value: '{value}' is too long.")
        => Value = value;
}