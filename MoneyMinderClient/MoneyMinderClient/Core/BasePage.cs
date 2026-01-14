using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
                Snackbar.Add(error, Severity.Error);
        }
    }
    
    protected virtual Task RefreshDataAsync()
        => Task.CompletedTask;
}