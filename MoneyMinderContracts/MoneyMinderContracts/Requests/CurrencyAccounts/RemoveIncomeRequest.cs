namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public record RemoveIncomeRequest(Guid CurrencyAccountId, Guid IncomeId);