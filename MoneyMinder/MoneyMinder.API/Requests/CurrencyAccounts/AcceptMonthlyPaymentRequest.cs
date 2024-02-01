using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record AcceptMonthlyPaymentRequest(Guid Id, string Name, decimal Amount, Currency Currency);