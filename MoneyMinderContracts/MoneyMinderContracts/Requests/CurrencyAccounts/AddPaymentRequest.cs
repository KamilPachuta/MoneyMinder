using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.CurrencyAccounts;

public record AddPaymentRequest(Guid CurrencyAccountId, string Name, DateTime Date, CurrencyDto CurrencyDto, decimal Amount, CategoryDto CategoryDto);