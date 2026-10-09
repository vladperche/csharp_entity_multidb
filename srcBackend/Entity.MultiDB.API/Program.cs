using Serilog;
using Entity.MultiDB.CrossCutting.Extensions;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, flushToDiskInterval: TimeSpan.FromDays(7))
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseContext();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();
if (args.Contains("--migrate-only"))
{
    app.Services.MigrateDatabase();
    return;
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
