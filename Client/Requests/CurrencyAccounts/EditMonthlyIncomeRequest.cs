namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditMonthlyIncomeRequest(Guid Id, string Name, string NewName, decimal NewAmount);
