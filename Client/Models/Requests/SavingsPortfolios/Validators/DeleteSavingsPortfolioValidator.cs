using Client.Models.Requests.SavingsPortfolios.Commands;
using FluentValidation;

namespace Client.Models.Requests.SavingsPortfolios.Validators;

public sealed class DeleteSavingsPortfolioValidator : AbstractValidator<DeleteSavingsPortfolioRequest>
{
    public DeleteSavingsPortfolioValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<DeleteSavingsPortfolioRequest>.CreateWithOptions((DeleteSavingsPortfolioRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}