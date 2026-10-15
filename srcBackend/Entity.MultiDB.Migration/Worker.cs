
namespace Entity.MultiDB.Migration;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("### Starting MIGRATION ###");

        
    }
}
