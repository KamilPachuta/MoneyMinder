namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AcceptMonthlyPaymentRequest(Guid CurrencyAccountId, string Name, decimal Amount);