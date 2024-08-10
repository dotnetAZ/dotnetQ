using dotnetQ.Abstractions.Configurations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetQ._IocConfig
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
        }
    }
}
