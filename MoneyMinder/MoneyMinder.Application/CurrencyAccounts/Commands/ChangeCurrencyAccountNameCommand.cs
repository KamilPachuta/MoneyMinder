using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;
using MoneyMinder.Domain.Shared.ValueObjects;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record ChangeCurrencyAccountNameCommand(Guid AccountId, Guid CurrencyAccountId, string Name) 
    : CurrencyCommand(AccountId, CurrencyAccountId);