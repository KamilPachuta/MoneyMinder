using Client.Models.Enums;

namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record ConvertCurrencyToRequest(Guid Id, Currency From, Currency To, decimal Amount, decimal Coefficient);