using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;


internal sealed class MonthlyIncomeNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public MonthlyIncomeNotFoundException(Guid id)
        : base($"Monthly income with id: '{id}' not found.")
    {
        Id = id;
    }
}