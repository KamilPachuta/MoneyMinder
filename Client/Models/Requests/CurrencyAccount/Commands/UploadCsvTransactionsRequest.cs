using Microsoft.AspNetCore.Components.Forms;

namespace Client.Models.Requests.CurrencyAccount.Commands;

public class UploadCsvTransactionsRequest
{
    public Guid CurrencyAccountId { get; set; }
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    public IBrowserFile File { get; set; }

    public UploadCsvTransactionsRequest()
    {
        
    }
    
    public UploadCsvTransactionsRequest(Guid currencyAccountId,DateTime from, DateTime to, IBrowserFile file)
    {
        CurrencyAccountId = currencyAccountId;
        File = file;
    }
}