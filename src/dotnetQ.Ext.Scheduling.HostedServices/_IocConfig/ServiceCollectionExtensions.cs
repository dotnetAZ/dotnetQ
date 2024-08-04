using dotnetQ.Abstractions.Configurations;
using dotnetQ.Scheduling.HostedServices.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetQ.Scheduling.HostedServices._IocConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDotnetQ(this IServiceCollection services,
            IHostEnvironment hostEnvironment,
            QConfigurations qConfigurations)
        {
            var qHostInfo = new QHostInfo()
            {
                MachineName = Environment.MachineName,
                ProcessId = Environment.ProcessId,
                EnvironmentName = hostEnvironment.EnvironmentName,
                ServerSessionId = Guid.NewGuid()
            };
            services.AddSingleton(qHostInfo);
            services.AddSingleton(qConfigurations);

            // -----------

            services.AddHostedService<WorkerRegistrationHostedService>();
            services.AddHostedService<WorkerHeartBeatHostedService>();
            services.AddHostedService<WorkerTerminatorHostedService>();
        }
    }
}
