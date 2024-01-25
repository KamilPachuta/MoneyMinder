using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Exceptions;


internal sealed class MonthlyPaymentNotFoundException : MoneyMinderException
{
    public Guid Id { get; }

    public MonthlyPaymentNotFoundException(Guid id)
        : base($"Monthly payment with id: '{id}' not found.")
    {
        Id = id;
    }
}