namespace MoneyMinderContracts.Requests.SavingsAccounts;

public record ChangeSavingsAccountNameRequest(Guid SavingsAccountId, string Name);