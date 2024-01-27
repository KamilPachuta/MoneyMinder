namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemoveMonthlyIncomeRequest(Guid Id, string MonthlyIncomeName);
