using Client.Models.Requests.SavingsPortfolios.Commands;
using FluentValidation;

namespace Client.Models.Requests.SavingsPortfolios.Validators;

public sealed class ChangeSavingsPlannedAmountValidator : AbstractValidator<ChangeSavingsPlannedAmountRequest>
{
    public ChangeSavingsPlannedAmountValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.PlannedAmount)
            .NotEmpty()
            .GreaterThan(0);
            //.WithMessage("Planned amount must be greater than 0.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ChangeSavingsPlannedAmountRequest>.CreateWithOptions((ChangeSavingsPlannedAmountRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}