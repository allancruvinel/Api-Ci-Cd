using Api.Server.Interfaces;
using Api.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ICalculatorService, CalculatorService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }
