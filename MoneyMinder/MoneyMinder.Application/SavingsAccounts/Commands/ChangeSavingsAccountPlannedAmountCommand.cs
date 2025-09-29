using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;

namespace MoneyMinder.Application.SavingsAccounts.Commands;

public record ChangeSavingsAccountPlannedAmountCommand(Guid AccountId, Guid SavingsAccountId, decimal PlannedAmount) 
    : SavingsCommand(AccountId, SavingsAccountId);