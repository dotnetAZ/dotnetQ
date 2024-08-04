using dotnetQ.Abstractions.Configurations;
using dotnetQ.Abstractions.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetQ.Scheduling.HostedServices.Services;

public class WorkerTerminatorHostedService : BackgroundService
{
    private readonly QConfigurations _qConfigurations;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public WorkerTerminatorHostedService(
        QHostInfo hostEnvironmentInfo,
        QConfigurations qConfigurations,
        IServiceScopeFactory serviceScopeFactory)
    {
        _qConfigurations = qConfigurations;
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await using var scope = _serviceScopeFactory.CreateAsyncScope();
        var _workerRepository = scope.ServiceProvider.GetRequiredService<IWorkerRepository>();
        try
        {

            var terminatedWorkers = await _workerRepository.TerminateInactiveWorkers(_qConfigurations.Worker.TerminationIntervalInSeconds);

            foreach (var worker in terminatedWorkers)
            {
                //_schedulerProvider.RemoveRecurringJob(DistributeQueueTypes.Inbox.PickAndReleaseRecurringJobName(worker.MachineName, worker.ProcessId));
                //_schedulerProvider.RemoveRecurringJob(DistributeQueueTypes.Outbox.PickAndReleaseRecurringJobName(worker.MachineName, worker.ProcessId));
                //_schedulerProvider.RemoveRecurringJob(DistributeQueueTypes.Queue.PickAndReleaseRecurringJobName(worker.MachineName, worker.ProcessId));
                //_schedulerProvider.DeleteQueueJobs(QueueRecurringJobNameHelper.GetQueueName(worker.MachineName, worker.ProcessId));
            }

            await Task.Delay(TimeSpan.FromSeconds(_qConfigurations.Worker.TerminationIntervalInSeconds), stoppingToken);
        }
        catch (Exception)
        {
        }
    }
}