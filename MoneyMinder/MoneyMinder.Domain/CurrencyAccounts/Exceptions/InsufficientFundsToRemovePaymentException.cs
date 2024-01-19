using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;


internal sealed class InsufficientFundsToRemovePaymentException : MoneyMinderException
{
    public Payment Payment { get; set; }
    
    public InsufficientFundsToRemovePaymentException(Payment payment)
        : base("Insufficient funds to remove the payment.")
    {
        Payment = payment;
    }
}