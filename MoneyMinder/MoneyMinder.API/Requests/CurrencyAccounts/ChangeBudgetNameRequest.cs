namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record ChangeBudgetNameRequest(Guid CurrencyAccountId, string Name);