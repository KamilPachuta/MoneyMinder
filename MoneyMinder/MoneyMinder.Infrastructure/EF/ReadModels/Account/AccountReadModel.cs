using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Infrastructure.EF.ReadModels.CurrencyAccount;
using MoneyMinder.Infrastructure.EF.ReadModels.Savings;

namespace MoneyMinder.Infrastructure.EF.ReadModels.Account;

public class AccountReadModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string PasswordHash { get; set; }

    public UserReadModel? User { get; set; }
    public IEnumerable<CurrencyAccountReadModel> CurrencyAccounts { get; set; }
    public IEnumerable<SavingsPortfolioReadModel> SavingsPortfolios { get; set; }
    public IEnumerable<NotificationReadModel> Notifications { get; set; }

    public AccountReadModel()
    {
        
    }
    
    public AccountReadModel(Guid id, string email, Role role, string passwordHash)
    {
        Id = id;
        Email = email;
        Role = role;
        PasswordHash = passwordHash;
    }
}