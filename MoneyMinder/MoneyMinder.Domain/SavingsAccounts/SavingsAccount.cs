using MoneyMinder.Domain.Accounts;
using MoneyMinder.Domain.Shared.Primitives;

namespace MoneyMinder.Domain.SavingsAccounts;

public class SavingsAccount : AggregateRoot
{
    
    
    public Account Account { get; init; }
    
    
}