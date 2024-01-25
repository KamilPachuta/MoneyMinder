namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemoveMonthlyIncomeRequest(Guid CurrencyAccountId, string MonthlyIncomeName);
