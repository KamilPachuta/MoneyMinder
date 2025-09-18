using MoneyMinder.Domain.Accounts.Enum;

namespace MoneyMinder.Infrastructure.EF.ReadModels.Accounts;

public class AccountReadModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string PasswordHash { get; set; }

    public UserReadModel? User { get; set; }
    //public IEnumerable<CurrencyAccountReadModel> CurrencyAccounts { get; set; }
    //public IEnumerable<SavingsPortfolioReadModel> SavingsPortfolios { get; set; }
    //public IEnumerable<NotificationReadModel> Notifications { get; set; }

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