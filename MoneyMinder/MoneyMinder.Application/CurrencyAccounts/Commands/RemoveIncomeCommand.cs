using MoneyMinder.Application.CurrencyAccounts.Commands.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record RemoveIncomeCommand(Guid AccountId, Guid CurrencyAccountId, Guid IncomeId) 
    : CurrencyCommand(AccountId, CurrencyAccountId);