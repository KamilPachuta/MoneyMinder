using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MoneyMinderClient.Core;

public class BasePage : ComponentBase
{
    [Inject] protected IDialogService DialogService { get; set; }
    [Inject] protected ISnackbar Snackbar { get; set; }
    [Inject] protected NavigationManager NavigationManager { get; set; }
    
    private ObservableCollection<string> _errors = new();

    protected override void OnInitialized()
    {
        _errors.CollectionChanged += Errors_CollectionChanged;
    }
    
    protected void SetErrors(IEnumerable<string> errors)
    {
        _errors.Clear();
        foreach (var err in errors)
            _errors.Add(err);
    }
    protected void SetError(string error)
    {
        _errors.Clear();
        if (!string.IsNullOrWhiteSpace(error)) 
            _errors.Add(error);
    }
 
    
    private void Errors_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add && e.NewItems is not null)
        {
            foreach (var item in e.NewItems)
            {
                var msg = item?.ToString();
                if (!string.IsNullOrWhiteSpace(msg))
                {
                    InvokeAsync(() =>
                    {
                        Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
                        Snackbar.Configuration.SnackbarVariant = Variant.Filled;
                        Snackbar.Add(msg, Severity.Error);
                    });
                }
            }
        }
    }
    protected async Task ShowDialogAsync<TDialog>(string title ,DialogParameters? parameters = null)
        where TDialog : ComponentBase
    {
        var dialog = await DialogService.ShowAsync<TDialog>(title, parameters ?? new DialogParameters());
        var result = await dialog.Result;

        if (result.Canceled)
        {
            Snackbar.Add("Operation canceled", Severity.Info);
            return;
        }

        var dialogResult = await dialog.GetReturnValueAsync<Result>();

        if (dialogResult.Succeeded)
        {
            Snackbar.Add("Operation successful", Severity.Success);
            await RefreshDataAsync();
        }
        else
        {
            Snackbar.Add("Operation failed", Severity.Error);

            foreach (var error in dialogResult.ErrorList)
            {
                if (error.Contains("Content"))
                {
                    var er = ExtractError(error);
                    var (e,m) = ExtractSimple(er);
                    
                    Snackbar.Add(m, Severity.Error);
                }
                else
                {
                    Snackbar.Add(error, Severity.Error);
                }
                    
                
            }
        }
    }
    
    protected virtual Task RefreshDataAsync()
        => Task.CompletedTask;
    
        

  
    private static (string ExceptionName, string Message) ExtractSimple(string text)
    {
        // usuń początek
        text = text.Replace("Exception occurred:", "").Trim();

        // podziel po ".Message:"
        var parts = text.Split(".Message:");

        var exceptionName = parts[0]
            .Replace("'", "")
            .Trim();

        var message = parts.Length > 1
            ? parts[1].Replace("'", "").Trim()
            : "";

        return (exceptionName, message);
    }


    private static string ExtractError(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return raw;

        // Wytnij sam JSON z tekstu (np. gdy masz "Content:\n{...}")
        var first = raw.IndexOf('{');
        var last  = raw.LastIndexOf('}');

        if (first >= 0 && last > first)
        {
            var jsonPart = raw.Substring(first, last - first + 1);

            try
            {
                using var doc = JsonDocument.Parse(jsonPart);

                if (doc.RootElement.TryGetProperty("detail", out var detail))
                    return detail.GetString() ?? raw;

                if (doc.RootElement.TryGetProperty("title", out var title))
                    return title.GetString() ?? raw;

                return raw;
            }
            catch
            {
                // jakby ten środek też nie był JSON-em
            }
        }

        // Fallback: spróbuj wyciągnąć tekst między "detail":" ... "
        // (gdyby JSON był np. uszkodzony/ucięty)
        var marker = "\"detail\":\"";
        var start = raw.IndexOf(marker, StringComparison.Ordinal);
        if (start >= 0)
        {
            start += marker.Length;
            var end = raw.IndexOf("\"", start, StringComparison.Ordinal);
            if (end > start)
                return raw.Substring(start, end - start);
        }

        return raw;
    }


    
}