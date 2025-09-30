using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.SavingsAccounts;

public record CreateSavingsAccountRequest(string Name, CurrencyDto CurrencyDto, decimal PlannedAmount);

