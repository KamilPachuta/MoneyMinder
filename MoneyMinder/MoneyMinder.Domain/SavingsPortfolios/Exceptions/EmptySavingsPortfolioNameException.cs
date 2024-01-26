using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.SavingsPortfolios.Exceptions;

internal sealed class EmptySavingsPortfolioNameException : MoneyMinderException
{
    public EmptySavingsPortfolioNameException()
        : base("SavingsPortfolioName cannot be empty.")
    {
    }
}