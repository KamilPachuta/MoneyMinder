using Client.Models.Enums;
using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class AcceptMonthlyPaymentValidator : AbstractValidator<AcceptMonthlyPaymentRequest>
{
    public AcceptMonthlyPaymentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);
        
        RuleFor(x => x.Amount)
            .NotEmpty()
            .LessThan(0);
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<AcceptMonthlyPaymentRequest>.CreateWithOptions((AcceptMonthlyPaymentRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}