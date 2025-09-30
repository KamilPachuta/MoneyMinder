using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.Requests.SavingsAccounts;

public record ProcessSavingsTransactionRequest(
    Guid SavingsAccountId, 
    string Name, 
    DateTime Date, 
    CurrencyDto CurrencyDto, 
    decimal Amount, 
    TransactionTypeDto TransactionTypeDto);