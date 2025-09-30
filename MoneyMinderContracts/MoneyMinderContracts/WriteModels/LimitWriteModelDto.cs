using MoneyMinderContracts.Enums;

namespace MoneyMinderContracts.WriteModels;

public record LimitWriteModelDto(CategoryDto CategoryDto, decimal Amount);