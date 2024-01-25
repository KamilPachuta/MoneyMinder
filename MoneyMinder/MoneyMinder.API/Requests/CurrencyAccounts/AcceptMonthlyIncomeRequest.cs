namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AcceptMonthlyIncomeRequest(Guid CurrencyAccountId, string Name, decimal Amount);