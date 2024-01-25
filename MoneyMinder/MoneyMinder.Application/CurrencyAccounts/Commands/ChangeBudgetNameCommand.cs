using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record ChangeBudgetNameCommand(Guid AccountId, Guid CurrencyAccountId, string Name) : CurrencyCommand(AccountId, CurrencyAccountId);