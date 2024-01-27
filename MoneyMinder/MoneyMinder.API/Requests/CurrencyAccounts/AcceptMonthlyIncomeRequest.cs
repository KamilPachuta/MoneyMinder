namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AcceptMonthlyIncomeRequest(Guid Id, string Name, decimal Amount);