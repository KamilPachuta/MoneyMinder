using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.Savings.Exceptons;

internal sealed class EmptySavingsPortfolioNameException : MoneyMinderException
{
    public EmptySavingsPortfolioNameException()
        : base("SavingsPortfolioName cannot be empty.")
    {
    }
}