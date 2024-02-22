
using Client.Models.Requests.CurrencyAccount.Commands;
using FluentValidation;


namespace Client.Models.Requests.CurrencyAccount.Validators;

public sealed class UploadCsvTransactionsValidator : AbstractValidator<UploadCsvTransactionsRequest>
{
    public UploadCsvTransactionsValidator()
    {
        RuleFor(x => x.CurrencyAccountId)
            .NotEmpty();

        RuleFor(x => x.From)
            .NotNull()
            .Must(f => f <= DateTime.UtcNow)
            .WithMessage("Date must be in past");

        RuleFor(x => x.To)
            .NotNull()
            .Must(t => t <= DateTime.UtcNow)
            .WithMessage("Date to must be later than date from");

        RuleFor(x => x.File)
            .NotEmpty();
    }
    
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result = await ValidateAsync(ValidationContext<UploadCsvTransactionsRequest>.CreateWithOptions((UploadCsvTransactionsRequest)model, x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };
    
}