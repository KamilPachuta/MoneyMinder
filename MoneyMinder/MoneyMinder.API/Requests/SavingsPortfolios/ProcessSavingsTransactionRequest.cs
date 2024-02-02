using MoneyMinder.Domain.CurrencyAccounts.Enums;
using MoneyMinder.Domain.SavingsPortfolios.Enums;

namespace MoneyMinder.API.Requests.SavingsPortfolios;

public record ProcessSavingsTransactionRequest(Guid Id, string Name, DateTime Date, decimal Amount, TransactionType Type);