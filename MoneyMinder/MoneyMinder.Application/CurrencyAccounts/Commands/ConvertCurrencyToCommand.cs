using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record ConvertCurrencyToCommand(
    Guid AccountId, Guid CurrencyAccountId, 
    Currency From, Currency To, 
    decimal Amount, decimal Coefficient) 
    : CurrencyCommand(AccountId, CurrencyAccountId);