namespace MoneyMinder.API.Requests.SavingsAccounts;

public record ChangeSavingsAccountPlannedAmountRequest(Guid SavingsAccountId, decimal PlannedAmount);