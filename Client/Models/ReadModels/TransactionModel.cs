

using Client.Models.Enums;

namespace Client.Models.ReadModels;

public record TransactionModel(Guid Id, string Name, DateTime Date, Currency Currency, decimal Amount, Category? Category);