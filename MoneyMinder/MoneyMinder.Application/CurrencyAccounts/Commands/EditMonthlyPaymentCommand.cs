using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record EditMonthlyPaymentCommand(Guid AccountId, Guid CurrencyAccountId, string Name, string NewName, decimal NewAmount, Category NewCategory) : CurrencyCommand(AccountId, CurrencyAccountId);