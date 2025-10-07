namespace MoneyMinderClient.Core;

  

public static class PathBuilder
{
    public static string CurrencyAcountPath(string name) => $"/CurrencyAccount/{name}";

    public static string CurrencyTransactionHistoryPath(string name) => $"/CurrencyAccount/{name}/TransactionHistory";
            
    public static string BudgetPath(string name) => $"/CurrencyAccount/{name}/Budget";
    
    public static string SavingsAccountPath(string name) => $"/SavingsAccount/{name}";
}