namespace MoneyMinder.API.Requests.SavingsAccounts;

public record ChangeSavingsAccountNameRequest(Guid SavingsAccountId, string Name);