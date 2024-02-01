using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsPortfolios.Validators;

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
}