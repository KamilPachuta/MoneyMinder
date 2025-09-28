using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddPaymentRequest(Guid CurrencyAccountId, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category);