
using Microsoft.Extensions.Hosting;

namespace LicenseService.BackgroundJobs
{
    public class LicenseExpiryJob : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Placeholder expiry logic
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
