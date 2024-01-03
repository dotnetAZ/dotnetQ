using Microsoft.Extensions.Hosting;

namespace dotnetQ.Scheduler.ServiceWorker
{
    public class QProcessWorker : BackgroundService
    {

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
