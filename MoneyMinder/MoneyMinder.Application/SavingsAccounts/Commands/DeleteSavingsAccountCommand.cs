using MediatR;
using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Commands;

public record DeleteSavingsAccountCommand(Guid AccountId, Guid SavingsAccountId) 
    : SavingsCommand(AccountId, SavingsAccountId);