
using Serilog;
using Entity.MultiDB.CrossCutting.Extensions;
using Microsoft.AspNetCore.Builder;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day, flushToDiskInterval: TimeSpan.FromDays(7))
    .CreateLogger();

Log.Information("%% Init: App Building Config");
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDatabaseContext();

Log.Information("%% Init: App Execution");
var app = builder.Build();
app.Services.MigrateDatabase();
