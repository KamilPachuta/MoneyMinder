using Carter;
using MoneyMinder.API;
using MoneyMinder.API.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("credentials.json", optional: true, reloadOnChange: true);
builder.Host.AddSerilog();
builder.Services.AddCors();

builder.Services.AddCarter();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProject(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    foreach (var assembly in assemblies)
    {
        cfg.RegisterServicesFromAssembly(assembly);
    }
});



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
