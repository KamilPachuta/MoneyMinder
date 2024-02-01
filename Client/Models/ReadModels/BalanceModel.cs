
using Client.Models.Enums;

namespace Client.Models.ReadModels;

public record BalanceModel(Guid Id, Currency Currency, decimal Amount);