using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AddPaymentCommand(Guid AccountId, Guid CurrencyAccountId, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category) : CurrencyCommand(AccountId, CurrencyAccountId);