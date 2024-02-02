using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Blazored.LocalStorage;
using Client;
using MudBlazor.Services;
using Client.Components;
using Client.Services;
using Client.Services.Interfaces;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");



builder.Services.AddMudServices();
builder.Services.AddScoped<BearerHandler>();

builder.Services.AddHttpClient("Auth", client =>
{
    client.BaseAddress = new Uri("http://localhost:5105/");
}).AddHttpMessageHandler<BearerHandler>();//.AddHttpMessageHandler<BearerHandler>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5105/") });



builder.Services.AddScoped<MoneyMinderAuthenticationStateProvider>();

builder.Services.AddScoped<AuthenticationStateProvider, MoneyMinderAuthenticationStateProvider>();

builder.Services.AddScoped(
    sp => (IAccountService)sp.GetRequiredService<AuthenticationStateProvider>());

builder.Services.AddScoped<ICurrencyAccountService, CurrencyAccountService>();
builder.Services.AddScoped<ISavingsService, SavingsService>();


builder.Services.AddAuthorizationCore();

builder.Services.AddBlazoredLocalStorageAsSingleton();

// builder.Services.AddHttpClient("Auth", client =>
// {
//     client.BaseAddress = new Uri("https://localhost:7189");
// }).AddHttpMessageHandler<BearerHandler>();


await builder.Build().RunAsync();

