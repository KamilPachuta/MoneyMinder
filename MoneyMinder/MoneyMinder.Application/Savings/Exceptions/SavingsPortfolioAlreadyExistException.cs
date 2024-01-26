using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.Savings.Exceptions;

internal sealed class SavingsPortfolioAlreadyExistException : MoneyMinderException
{
    public string Name { get; }

    public SavingsPortfolioAlreadyExistException(string name)
        : base($"Savings portfolio with name: '{name}' already exist.")
    {
        Name = name;
    }
}