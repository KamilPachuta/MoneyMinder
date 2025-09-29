using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record DeleteBudgetCommand(Guid AccountId, Guid CurrencyAccountId) 
    : CurrencyCommand(AccountId, CurrencyAccountId);
