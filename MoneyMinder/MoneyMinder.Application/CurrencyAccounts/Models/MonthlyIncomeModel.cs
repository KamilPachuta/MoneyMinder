using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

public record MonthlyIncomeModel(Guid Id, string Name, DateTime Month, Currency Currency, decimal Amount);
