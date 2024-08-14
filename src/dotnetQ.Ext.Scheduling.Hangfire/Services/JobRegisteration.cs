using dotnetQ.Abstractions.Attributes;
using dotnetQ.Abstractions.Configurations;
using dotnetQ.Abstractions.Services;
using Hangfire;

namespace dotnetQ.Ext.Scheduling.Hangfire
{
    public class JobRegisteration
    {
        public readonly IBackgroundJobClient _backgroundJobClient;
        public readonly IRecurringJobManager _recurringJobManager;
        private readonly QConfigurations _qConfigurations;

        public JobRegisteration(
            IBackgroundJobClient backgroundJobClient,
            IRecurringJobManager recurringJobManager,
            QConfigurations qConfigurations)
        {
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
            _qConfigurations = qConfigurations;
        }

        public async Task Register()
        {
            _recurringJobManager.AddOrUpdate<IPackGeneratorRecurringJob>(
                QueueEnum.Inbox.PackGeneratorRecurringJob(),
                action => action.Execute(QueueEnum.Inbox, default),
                _qConfigurations.PackGeneratorCron
            );
        }

    }
}
