using dotnetQ.Ext.Scheduling.HostedServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetQ.Ext.Scheduling.HostedServices._IocConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDotnetQHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<WorkerRegistrationHostedService>();
            services.AddHostedService<WorkerHeartBeatHostedService>();
            services.AddHostedService<WorkerTerminatorHostedService>();
        }
    }
}
