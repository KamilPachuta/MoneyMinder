using FluentValidation;
using MoneyMinderContracts.Requests.Accounts;
using MoneyMinderContracts.Requests.Accounts.Validators;

namespace MoneyMinderClient.Adapters;

public static class LoginAccountValidationAdapter
{
    private static readonly LoginAccountValidator _validator = new();

    public static Func<object, string, Task<IEnumerable<string>>> ValidateValue =>
        async (model, propertyName) =>
        {
            var context = ValidationContext<LoginAccountRequest>.CreateWithOptions(
                (LoginAccountRequest)model,
                x => x.IncludeProperties(propertyName)
            );

            var result = await _validator.ValidateAsync(context);
            return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
        };
}