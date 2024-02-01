using Client.Models.Enums;
using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace MoneyMinder.API.Requests.CurrencyAccounts.Validators;

public sealed class AddIncomeValidator : AbstractValidator<AddIncomeRequest>
{
    public AddIncomeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty();
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .GreaterThan(0);
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AddIncomeRequest>.CreateWithOptions((AddIncomeRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}