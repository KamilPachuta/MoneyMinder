using Client.Models.Enums;

namespace Client.Models.ReadModels;

public record MonthlyTransactionModel(Guid Id, string Name, DateTime Month, Currency Currency, decimal Amount, Category? Category);
