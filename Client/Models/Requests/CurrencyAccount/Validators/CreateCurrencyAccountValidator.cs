using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class CreateCurrencyAccountValidator : AbstractValidator<CreateCurrencyAccountRequest>
{
    public CreateCurrencyAccountValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateCurrencyAccountRequest>.CreateWithOptions((CreateCurrencyAccountRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}