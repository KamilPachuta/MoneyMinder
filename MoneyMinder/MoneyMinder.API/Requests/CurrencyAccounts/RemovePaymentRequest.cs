namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemovePaymentRequest(Guid CurrencyAccountId, Guid PaymentId);
