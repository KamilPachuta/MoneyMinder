using Client.Models.Enums;
using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;
using MoneyMinder.API.Requests.CurrencyAccounts;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class AddMonthlyPaymentValidator : AbstractValidator<AddMonthlyPaymentRequest>
{
    public AddMonthlyPaymentValidator()
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
            .LessThan(0);

        RuleFor(x => x.Category)
            .Must(value => Enum.IsDefined(typeof(Category), value))
            .WithMessage("Invalid value for the Category field.");
    }   
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AddMonthlyPaymentRequest>.CreateWithOptions((AddMonthlyPaymentRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    }; 
}