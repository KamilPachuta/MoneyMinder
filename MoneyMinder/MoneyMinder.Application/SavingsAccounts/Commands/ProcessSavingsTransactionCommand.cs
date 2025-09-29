using MoneyMinder.Application.SavingsAccounts.Commands.Abstractions;
using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.Application.SavingsAccounts.Commands;

public record ProcessSavingsTransactionCommand(
    Guid AccountId, 
    Guid SavingsAccountId, 
    string Name, 
    DateTime Date, 
    Currency Currency, 
    decimal Amount, 
    TransactionType TransactionType) 
    : SavingsCommand(AccountId, SavingsAccountId);