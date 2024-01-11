using MoneyMinder.Domain.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Entities;

namespace MoneyMinder.Domain.CurrencyAccounts.Exceptions;

public class InsufficientFundsException(Transaction transaction) : MoneyMinderException($"Not enough funds to proceed with the transaction: {transaction}");
