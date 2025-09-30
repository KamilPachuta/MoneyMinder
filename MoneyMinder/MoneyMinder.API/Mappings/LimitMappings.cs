using MoneyMinder.Application.CurrencyAccounts.Models;
using MoneyMinderContracts.WriteModels;
using MoneyMinder.Domain.Shared.Enums;

namespace MoneyMinder.API.Mappings;

public static class LimitMappings
{
    public static LimitWriteModel ToDomain(this LimitWriteModelDto dto) =>
        new LimitWriteModel((Category)dto.CategoryDto, dto.Amount);

    public static IEnumerable<LimitWriteModel> ToDomain(this IEnumerable<LimitWriteModelDto> dtos) =>
        dtos.Select(dto => dto.ToDomain());
}
