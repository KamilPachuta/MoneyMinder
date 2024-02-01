using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;
using MoneyMinder.API.Requests.CurrencyAccounts;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class ChangeCurrencyAccountNameValidator : AbstractValidator<ChangeCurrencyAccountNameRequest>
{
    public ChangeCurrencyAccountNameValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ChangeCurrencyAccountNameRequest>.CreateWithOptions((ChangeCurrencyAccountNameRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}