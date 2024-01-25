using Carter;
using MoneyMinder.API;
using MoneyMinder.API.Middleware;
using MoneyMinder.Application.Behaviors;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("credentials.json", optional: true, reloadOnChange: true);

builder.Host.AddSerilog();

builder.Services.AddCors();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddProject(builder.Configuration);




var app = builder.Build();

app.UseCors(builder =>
{
    builder.WithOrigins("https://localhost:44398") // Domeny FrontEnd
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<RequestLogContextMiddleware>();

app.UseSerilogRequestLogging();

app.MapCarter();

app.Run();
