using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AddMonthlyPaymentRequest(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category);