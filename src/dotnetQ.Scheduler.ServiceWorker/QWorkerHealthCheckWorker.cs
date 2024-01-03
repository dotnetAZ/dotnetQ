using Microsoft.Extensions.Hosting;

namespace dotnetQ.Scheduler.ServiceWorker
{
    public class QWorkerHealthCheckWorker : BackgroundService
    {
        public QWorkerHealthCheckWorker()
        {
            
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {


                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}
