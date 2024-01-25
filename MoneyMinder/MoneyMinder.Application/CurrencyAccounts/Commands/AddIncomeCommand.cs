using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AddIncomeCommand(Guid AccountId, Guid CurrencyAccountId, string Name, DateTime Date, Currency Currency, decimal Amount) : CurrencyCommand(AccountId, CurrencyAccountId);