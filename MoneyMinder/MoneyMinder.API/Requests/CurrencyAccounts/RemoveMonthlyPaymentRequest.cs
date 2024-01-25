namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemoveMonthlyPaymentRequest(Guid CurrencyAccountId, string MonthlyPaymentName);
