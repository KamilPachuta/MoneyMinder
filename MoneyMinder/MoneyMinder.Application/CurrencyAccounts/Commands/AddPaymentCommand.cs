using MediatR;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.CurrencyAccounts.Commands;

public record AddPaymentCommand(Guid AccountId, Guid CurrencyAccountId, string Name, DateTime Date, Currency Currency, decimal Amount, Category Category) : IRequest;