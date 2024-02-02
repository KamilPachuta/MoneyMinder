using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios.Enums;

namespace MoneyMinder.Application.Savings.Models;


public record SavingsTransactionModel(Guid Id, TransactionType Type, string Name, DateTime Date, Currency Currency, decimal Amount);
