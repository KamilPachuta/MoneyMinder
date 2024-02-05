using Client.Models.Enums;
using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;
using MoneyMinder.API.Requests.CurrencyAccounts;

namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class CreateBudgetValidator : AbstractValidator<CreateBudgetRequest>
{
    public CreateBudgetValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50);
        
        RuleFor(x => x.ExpectedIncome)
            .NotEmpty()
            .GreaterThan(0);

        //RuleFor(x => x.Expenses);
        
        RuleFor(x => x.Date)
            .NotEmpty();
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateBudgetRequest>.CreateWithOptions((CreateBudgetRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}