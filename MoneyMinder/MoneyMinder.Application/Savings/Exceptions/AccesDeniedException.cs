using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.Savings.Exceptions;

internal sealed class AccesDeniedException : MoneyMinderException
{
    public Guid AccountId { get; }
    public Guid SavingsPortfolioId { get; }

    public AccesDeniedException(Guid accountId, Guid savingsPortfolioId)
        : base($"The account with ID: '{accountId}' is not the owner of the savings portfolio with ID: '{savingsPortfolioId}'. ")
    {
        AccountId = accountId;
        SavingsPortfolioId = savingsPortfolioId;
    }
}