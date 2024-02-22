namespace MoneyMinder.API.Requests.CurrencyAccounts;

public record UploadCsvTransactionsRequest(Guid CurrencyAccountId, IFormFile File);
