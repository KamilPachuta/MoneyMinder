using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddPaymentRequest(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category);
