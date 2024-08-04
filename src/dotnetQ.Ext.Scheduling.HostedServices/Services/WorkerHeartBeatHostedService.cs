using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetQ.Ext.Scheduling.HostedServices.Services
{
    public class WorkerHeartBeatHostedService : BackgroundService
    {
        private readonly QHostInfo _hostEnvironmentInfo;
        private readonly QConfigurations _qConfigurations;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WorkerHeartBeatHostedService(QHostInfo hostEnvironmentInfo,
            QConfigurations qConfigurations,
            IServiceScopeFactory serviceScopeFactory)
        {
            _hostEnvironmentInfo = hostEnvironmentInfo;
            _qConfigurations = qConfigurations;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            var _workerRepository = scope.ServiceProvider.GetRequiredService<IWorkerRepository>();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var isExist = await _workerRepository.GetWorkerToCheckExistence(_hostEnvironmentInfo.ServerSessionId, _hostEnvironmentInfo.MachineName, _hostEnvironmentInfo.ProcessId, _hostEnvironmentInfo.IsProduction);
                    if (isExist)
                    {
                        await _workerRepository.SetWorkerHeartBeat(_hostEnvironmentInfo.ServerSessionId, _hostEnvironmentInfo.MachineName, _hostEnvironmentInfo.ProcessId, _hostEnvironmentInfo.IsProduction);
                    }
                    else
                    {
                        await _workerRepository.AddWorker(Worker.AddWorker(
                            _hostEnvironmentInfo.ServerSessionId,
                            _hostEnvironmentInfo.MachineName,
                            _hostEnvironmentInfo.ProcessId,
                            _hostEnvironmentInfo.IsProduction));
                    }

                    await Task.Delay(TimeSpan.FromSeconds(_qConfigurations.Worker.HeartbeatIntervalInSeconds), stoppingToken);
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}