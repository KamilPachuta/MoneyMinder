using Client.Models.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record ConvertCurrencyFromRequest(Guid Id, Currency From, Currency To, decimal Amount, decimal Coefficient);