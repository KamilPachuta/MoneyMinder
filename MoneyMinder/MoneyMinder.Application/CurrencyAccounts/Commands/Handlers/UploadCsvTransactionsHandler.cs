using MediatR;
using MoneyMinder.Application.CurrencyAccounts.Commands.Handlers.Abstractions;
using MoneyMinder.Application.CurrencyAccounts.Services;
using MoneyMinder.Domain.Repository;

namespace MoneyMinder.Application.CurrencyAccounts.Commands.Handlers;

internal sealed class UploadCsvTransactionsHandler : CurrencyCommandHandler<UploadCsvTransactionsCommand>
{
    public UploadCsvTransactionsHandler(ICurrencyAccountRepository repository, ICurrencyAccountReadService readService) 
        : base(repository, readService)
    {
    }

    public override Task Handle(UploadCsvTransactionsCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        
        // if (file is not null && file.ContentType == "text/csv")
        // {
        //     // Obsługa przesłanego pliku CSV
        //     
        //     using var reader = new StreamReader(file.OpenReadStream());
        //     while (!reader.EndOfStream)
        //     {
        //         var line = await reader.ReadLineAsync();
        //         
        //         Console.WriteLine(line);
        //     }
        //
        //     await context.Response.WriteAsync("Plik CSV został przesłany i przetworzony poprawnie.");
        // }
        // else
        // {
        //     context.Response.StatusCode = StatusCodes.Status415UnsupportedMediaType;
        //     await context.Response.WriteAsync("Nieprawidłowy typ pliku. Wysyłany plik musi być w formacie CSV.");
        // }
    }
}