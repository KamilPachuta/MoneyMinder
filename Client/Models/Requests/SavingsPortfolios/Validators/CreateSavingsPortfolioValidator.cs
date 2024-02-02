using Client.Models.Enums;
using Client.Models.Requests.SavingsPortfolios.Commands;
using FluentValidation;

namespace Client.Models.Requests.SavingsPortfolios.Validators;

public sealed class CreateSavingsPortfolioValidator : AbstractValidator<CreateSavingsPortfolioRequest>
{
    public CreateSavingsPortfolioValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(40);
        
        RuleFor(x => x.Currency)
            .Must(value => Enum.IsDefined(typeof(Currency), value))
            .WithMessage("Invalid value for the Currency field.");
        
        RuleFor(x => x.PlannedAmount)
            .NotEmpty()
            .GreaterThan(0);
            //.WithMessage("Planned amount must be greater than 0.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<CreateSavingsPortfolioRequest>.CreateWithOptions((CreateSavingsPortfolioRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}