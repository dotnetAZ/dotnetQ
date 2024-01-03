using Microsoft.Extensions.Hosting;

namespace dotnetQ.Core.Scheduler
{
    public class QProcessWorker : BackgroundService
    {

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
