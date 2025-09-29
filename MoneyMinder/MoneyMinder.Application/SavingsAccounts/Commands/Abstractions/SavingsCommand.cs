using MediatR;

namespace MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;

public abstract record SavingsCommand(Guid AccountId, Guid SavingsAccountId) : IRequest;
