using Client.Models.Enums;

namespace MoneyMinder.API.Requests.SavingsPortfolios;

public record ProcessSavingsTransactionRequest(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, TransactionType Type);