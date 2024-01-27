namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record RemoveMonthlyPaymentRequest(Guid Id, string MonthlyPaymentName);
