using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyMinder.API;
using MoneyMinder.API.Middleware;
using MoneyMinder.API.Services;
using MoneyMinder.Application.Behaviors;
using MoneyMinder.Application.CurrencyAccounts.Commands;
using Serilog;
using SharpGrip.FluentValidation.AutoValidation.Endpoints.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("credentials.json", optional: true, reloadOnChange: true);

builder.Host.AddSerilog();

// builder.Services.AddCors();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontEnd", builder =>
    {
        builder.WithOrigins("https://localhost:7284")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddAntiforgery();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddProject(builder.Configuration);


builder.Services.AddFluentValidationAutoValidation();






var app = builder.Build();

// app.UseCors(builder =>
// {
//     builder.WithOrigins("https://localhost:7284") // Domeny FrontEnd
//         .AllowAnyHeader()
//         .AllowAnyMethod()
//         .AllowCredentials();
// });

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontEnd");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

// app.UseAntiforgery();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();



app.MapCarter();

app.Run();
