using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Accounts.Enum;
using MoneyMinder.Infrastructure.EF.ReadModels.Savings;

namespace MoneyMinder.Infrastructure.EF.ReadModels.Account;

public class AccountModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string PasswordHash { get; set; }

    public UserModel? User { get; set; }
    public IEnumerable<CurrencyAccountModel> CurrencyAccounts { get; set; }
    public IEnumerable<SavingsPortfolioModel> Type { get; set; }

    public AccountModel()
    {
        
    }
    
    public AccountModel(Guid id, string email, Role role, string passwordHash)
    {
        Id = id;
        Email = email;
        Role = role;
        PasswordHash = passwordHash;
    }
}