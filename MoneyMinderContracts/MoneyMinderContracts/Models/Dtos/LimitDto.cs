using MoneyMinderContracts.Models.Enums;

namespace MoneyMinderContracts.Models.Dtos;

public class LimitDto
{
    public CategoryDto CategoryDto { get; set; }
    public decimal Amount { get; set; }
}