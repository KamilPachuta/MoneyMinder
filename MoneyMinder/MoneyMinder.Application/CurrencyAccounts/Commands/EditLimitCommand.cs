using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Models;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record EditLimitCommand(Guid AccountId, Guid CurrencyAccountId, LimitWriteModel Limit) 
    : CurrencyCommand(AccountId, CurrencyAccountId);