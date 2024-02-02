using Client.Models.Enums;

namespace Client.Models.ReadModels;


public record SavingsPortfolioModel(Guid Id, string Name, Currency Currency, decimal PlannedAmount, decimal ActualAmount, IEnumerable<SavingsTransactionModel> Transactions);
