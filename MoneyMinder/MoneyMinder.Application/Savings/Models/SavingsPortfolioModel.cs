using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.Savings.Models;


public record SavingsPortfolioModel(Guid Id, string Name, Currency Currency, decimal PlannedAmount, decimal ActualAmount, IEnumerable<SavingsTransactionModel> Transactions);
