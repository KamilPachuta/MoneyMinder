using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public record LimitDto(CategoryDto CategoryDto, decimal Amount);