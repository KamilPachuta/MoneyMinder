using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record RemoveExpenseCommand(Guid AccountId, Guid CurrencyAccountId, Category Category) : CurrencyCommand(AccountId, CurrencyAccountId);