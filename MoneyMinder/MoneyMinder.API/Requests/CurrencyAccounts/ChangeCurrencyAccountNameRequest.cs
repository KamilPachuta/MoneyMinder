namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record ChangeCurrencyAccountNameRequest(Guid Id, string Name);