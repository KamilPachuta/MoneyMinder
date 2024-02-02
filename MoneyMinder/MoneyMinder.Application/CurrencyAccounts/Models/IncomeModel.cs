using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Models;

public record IncomeModel(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount);
