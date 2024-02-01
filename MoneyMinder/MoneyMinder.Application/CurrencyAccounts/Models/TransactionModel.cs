using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

public record TransactionModel(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, Category? Category);