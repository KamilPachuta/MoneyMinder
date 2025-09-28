using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record RemovePaymentCommand(Guid AccountId, Guid CurrencyAccountId, Guid PaymentId) 
    : CurrencyCommand(AccountId, CurrencyAccountId);
