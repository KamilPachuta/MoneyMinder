using MediatR;
using MoneyMinder.Domain.CurrencyAccounts.Enums;

namespace MoneyMinder.Application.Savings.Commands;

public record CreateSavingsPortfolioCommand(Guid AccountId, string Name, Currency Currency, decimal PlannedAmount) : IRequest;