using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsPortfolios.Validators;

public sealed class ChangeSavingsNameValidator : AbstractValidator<ChangeSavingsNameRequest>
{
    public ChangeSavingsNameValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(40);
    }
}