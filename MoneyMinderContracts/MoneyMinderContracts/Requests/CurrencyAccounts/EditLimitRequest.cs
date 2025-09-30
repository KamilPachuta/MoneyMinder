using MoneyMinderContracts.WriteModels;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public record EditLimitRequest(Guid CurrencyAccountId, LimitWriteModelDto Limit);