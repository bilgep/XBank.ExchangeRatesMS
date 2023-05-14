using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.Console;
using XBank.ExchangeService.Services;
using XBank.M01.ExchangeService.Persistence;



var builder = WebApplication.CreateBuilder(args);

using var loggerFactory = LoggerFactory.Create(b => b.AddConsole());
var logger = loggerFactory.CreateLogger<Program>();

builder.Logging.AddConfiguration();
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddHttpClient<ExchangeRateService, ExchangeRateService>();
builder.Services.AddScoped<ExchangeRateService>();
builder.Services.AddScoped<IExchangeRepositorty, ExchangeRepository>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

logger.LogInformation("Services injected");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

logger.LogInformation("Pipeline created");
app.Run();
