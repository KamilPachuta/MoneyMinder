using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditMonthlyPaymentRequest(Guid Id, string Name, string NewName, decimal NewAmount, Category NewCategory);
