using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

internal sealed class PaymentAlreadyExistException : MoneyMinderException
{
    public Payment Payment { get; set; }
    
    public PaymentAlreadyExistException(Payment payment)
        : base($"Payment: '{payment}' already exist.")
    {
        Payment = payment;
    }
    
}