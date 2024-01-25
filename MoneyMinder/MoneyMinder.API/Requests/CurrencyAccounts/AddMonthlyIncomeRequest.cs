using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddMonthlyIncomeRequest(Guid CurrencyAccountId, string Name, DateTime Date, Currency Currency, decimal Amount);