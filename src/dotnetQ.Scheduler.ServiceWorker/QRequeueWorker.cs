using Microsoft.Extensions.Hosting;

namespace dotnetQ.Core.Scheduler
{
    public class IQRequeueWorker : BackgroundService
    {

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
