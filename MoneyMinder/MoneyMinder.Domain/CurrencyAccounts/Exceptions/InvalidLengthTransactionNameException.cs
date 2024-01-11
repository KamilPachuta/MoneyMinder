using MoneyMinder.Domain.Abstractions;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;


internal sealed class InvalidLengthTransactionNameException(string name) : MoneyMinderException($"Currency account name: '{name}' is not between 1-50 characters.")
{
    public string Name { get; set; }
}