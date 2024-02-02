using Client.Models.Requests.SavingsPortfolios.Commands;
using FluentValidation;

namespace Client.Models.Requests.SavingsPortfolios.Validators;

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
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ChangeSavingsNameRequest>.CreateWithOptions((ChangeSavingsNameRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}