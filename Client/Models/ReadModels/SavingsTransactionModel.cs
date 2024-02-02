using Client.Models.Enums;

namespace Client.Models.ReadModels;


public record SavingsTransactionModel(Guid Id, TransactionType Type, string Name, DateTime Date, Currency Currency, decimal Amount);
