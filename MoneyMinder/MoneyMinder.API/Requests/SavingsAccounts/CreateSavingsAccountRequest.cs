using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.API.Requests.SavingsAccounts;

public record CreateSavingsAccountRequest(string Name, Currency Currency, decimal PlannedAmount);

