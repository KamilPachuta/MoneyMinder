using FluentValidation;

namespace MoneyMinder.API.Requests.SavingsPortfolios.Validators;

public sealed class DeleteSavingsPortfolioValidator : AbstractValidator<DeleteSavingsPortfolioRequest>
{
    public DeleteSavingsPortfolioValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}