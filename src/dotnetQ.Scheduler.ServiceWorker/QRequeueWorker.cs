using Microsoft.Extensions.Hosting;

namespace dotnetQ.Scheduler.ServiceWorker
{
    public class QRequeueWorker : BackgroundService
    {
        public QRequeueWorker()
        {
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

        }
    }
}
