using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record ConvertCurrencyToRequest(Guid CurrencyAccountId, Currency From, Currency To, decimal Amount, decimal Coefficient);