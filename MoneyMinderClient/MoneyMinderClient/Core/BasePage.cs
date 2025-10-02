using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace MoneyMinderClient.Core;

public class BasePage : ComponentBase
{
    [Inject] protected IDialogService DialogService { get; set; }
    [Inject] protected ISnackbar Snackbar { get; set; }
    [Inject] protected NavigationManager NavigationManager { get; set; }
    
    protected async Task ShowDialogAsync<TDialog>()
        where TDialog : ComponentBase
    {
        var dialog = await DialogService.ShowAsync<TDialog>();
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
            NavigationManager.Refresh();
        }
        else
        {
            Snackbar.Add("Operation failed", Severity.Error);
            foreach (var error in dialogResult.ErrorList)
                Snackbar.Add(error, Severity.Error);
        }
    }
}