using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record ConvertCurrencyCommand(Guid AccountId, Guid CurrencyAccountId, Currency From, Currency To, decimal Amount, decimal Coefficient) 
    : CurrencyCommand(AccountId, CurrencyAccountId);
