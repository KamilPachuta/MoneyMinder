namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemoveIncomeRequest(Guid CurrencyAccountId, Guid IncomeId);