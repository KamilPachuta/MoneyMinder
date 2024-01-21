using MoneyMinder.API;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("credentials.json", optional: true, reloadOnChange: true);

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



app.Run();
