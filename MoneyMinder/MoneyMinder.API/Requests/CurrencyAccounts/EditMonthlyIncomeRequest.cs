namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditMonthlyIncomeRequest(Guid CurrencyAccountId, string Name, string NewName, decimal NewAmount);
