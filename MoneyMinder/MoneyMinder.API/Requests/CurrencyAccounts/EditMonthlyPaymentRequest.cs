using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditMonthlyPaymentRequest(Guid CurrencyAccountId, string Name, string NewName, decimal NewAmount, Category NewCategory);
