namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public record RemovePaymentRequest(Guid CurrencyAccountId, Guid PaymentId);
