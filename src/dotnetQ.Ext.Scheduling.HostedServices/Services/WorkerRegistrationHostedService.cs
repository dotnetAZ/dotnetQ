using dotnetQ.Abstractions.Configurations;
using dotnetQ.Abstractions.Entities.QWorkers;
using dotnetQ.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetQ.Ext.Scheduling.HostedServices.Services
{
    public class WorkerRegistrationHostedService : BackgroundService
    {
        private readonly QHostInfo _hostEnvironmentInfo;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public WorkerRegistrationHostedService(
            QHostInfo hostEnvironmentInfo,
            IServiceScopeFactory serviceScopeFactory)
        {
            _hostEnvironmentInfo = hostEnvironmentInfo;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await using var scope = _serviceScopeFactory.CreateAsyncScope();
            var _workerRepository = scope.ServiceProvider.GetRequiredService<IWorkerRepository>();

            try
            {
                await _workerRepository.AddWorker(Worker.AddWorker(
                    _hostEnvironmentInfo.ServerSessionId,
                    _hostEnvironmentInfo.MachineName,
                    _hostEnvironmentInfo.ProcessId,
                    _hostEnvironmentInfo.IsProduction));
            }
            catch (Exception)
            {
            }
        }

    }
}