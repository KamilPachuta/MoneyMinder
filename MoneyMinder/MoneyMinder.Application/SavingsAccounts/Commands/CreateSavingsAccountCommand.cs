using MediatR;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Application.SavingsAccounts.Commands;

public record CreateSavingsAccountCommand(Guid AccountId, string Name, Currency Currency, decimal PlannedAmount) : IRequest;