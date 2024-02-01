using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record EditMonthlyIncomeCommand(Guid AccountId, Guid CurrencyAccountId, string Name, decimal NewAmount, Currency NewCurrency) : CurrencyCommand(AccountId, CurrencyAccountId);