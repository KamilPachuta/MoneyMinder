using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditMonthlyIncomeRequest(Guid Id, string Name, decimal NewAmount, Currency NewCurrency);
