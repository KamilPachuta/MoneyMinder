using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinder.Domain.Shared.Enums;
using MoneyMinderContracts.Models.Dtos;

namespace MoneyMinder.API.Mappings;

public static class LimitMappings
{
    public static LimitWriteModel ToDomain(this LimitDto dto) =>
        new LimitWriteModel((Category)dto.CategoryDto, dto.Amount);

    public static IEnumerable<LimitWriteModel> ToDomain(this IEnumerable<LimitDto> dtos) =>
        dtos.Select(dto => dto.ToDomain());
}
