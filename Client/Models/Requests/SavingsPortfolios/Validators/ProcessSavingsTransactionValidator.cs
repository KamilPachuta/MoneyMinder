using Client.Models.Enums;
using Client.Models.Requests.SavingsPortfolios.Commands;
using FluentValidation;

namespace Client.Models.Requests.SavingsPortfolios.Validators;

public sealed class ProcessSavingsTransactionValidator : AbstractValidator<ProcessSavingsTransactionRequest>
{
    public ProcessSavingsTransactionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(50);

        RuleFor(x => x.Date)
            .NotEmpty();

        RuleFor(x => x.Amount)
            .NotEmpty();

        RuleFor(x => x.Type)
            .Must(value => Enum.IsDefined(typeof(TransactionType), value))
            .WithMessage("Invalid value for the Type field.");
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<ProcessSavingsTransactionRequest>.CreateWithOptions((ProcessSavingsTransactionRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
}