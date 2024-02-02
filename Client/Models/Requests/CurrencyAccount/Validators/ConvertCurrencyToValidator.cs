using Client.Models.Enums;
using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class ConvertCurrencyToValidator : AbstractValidator<ConvertCurrencyToRequest>
{
    public ConvertCurrencyToValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.From)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the From field.");
        
        RuleFor(x => x.To)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the To field.");
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .GreaterThan(0);
        
        RuleFor(x => x.Coefficient)
            .NotEmpty()
            .GreaterThan(0);
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ConvertCurrencyToRequest>.CreateWithOptions((ConvertCurrencyToRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}