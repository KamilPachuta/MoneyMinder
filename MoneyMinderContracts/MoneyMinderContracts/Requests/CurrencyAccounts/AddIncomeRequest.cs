using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public record AddIncomeRequest(Guid CurrencyAccountId, string Name, DateTime Date, CurrencyDto CurrencyDto, decimal Amount);