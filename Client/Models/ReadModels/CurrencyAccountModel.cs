namespace Client.Models.ReadModels;

public record CurrencyAccountModel(
    Guid Id,
    string Name, 
    BudgetModel Budget, 
    IEnumerable<BalanceModel> Balances, 
    IEnumerable<TransactionModel> Transactions, 
    IEnumerable<MonthlyTransactionModel> MonthlyTransactions);