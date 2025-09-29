using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Commands;

public record ChangeSavingsAccountNameCommand(Guid AccountId, Guid SavingsAccountId, string Name) 
    : SavingsCommand(AccountId, SavingsAccountId);