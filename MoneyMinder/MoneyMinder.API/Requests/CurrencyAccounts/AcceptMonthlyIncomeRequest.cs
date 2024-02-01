using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AcceptMonthlyIncomeRequest(Guid Id, string Name, decimal Amount, Currency Currency);