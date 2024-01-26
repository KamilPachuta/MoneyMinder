using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.Savings.Exceptions;

internal sealed class SavingsPortfolioNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public SavingsPortfolioNotFoundException(Guid id)
        : base($"Savings portfolio with id: '{id}' not found.")
    {
        Id = id;
    }
}