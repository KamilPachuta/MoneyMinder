using FluentValidation;

namespace MoneyMinderClient.Core;

public static class ValidationAdapter
{
    public static Func<object, string, Task<IEnumerable<string>>> ValidateValue<TRequest>(IValidator<TRequest> validator)
        where TRequest : class
    {
        return async (model, propertyName) =>
        {
            var context = ValidationContext<TRequest>.CreateWithOptions(
                (TRequest)model,
                x => x.IncludeProperties(propertyName)
            );

            var result = await validator.ValidateAsync(context);
            return result.IsValid
                ? Array.Empty<string>()
                : result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
