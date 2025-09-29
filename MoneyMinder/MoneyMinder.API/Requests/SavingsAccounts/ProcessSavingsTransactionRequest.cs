using MoneyMinder.Domain.SavingsAccounts.Enums;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.API.Requests.SavingsAccounts;

public record ProcessSavingsTransactionRequest(
    Guid SavingsAccountId, 
    string Name, 
    DateTime Date, 
    Currency Currency, 
    decimal Amount, 
    TransactionType TransactionType);