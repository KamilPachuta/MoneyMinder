using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record EditLimitRequest(Guid CurrencyAccountId, LimitWriteModel Limit);