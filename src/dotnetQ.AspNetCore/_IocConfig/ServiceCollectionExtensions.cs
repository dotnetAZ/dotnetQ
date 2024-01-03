using dotnetQ.Abstractions.Models;
using dotnetQ.Abstractions.Services;
using dotnetQ.Abstractions.Storage;
using dotnetQ.Scheduler.ServiceWorker;
using dotnetQ.Storage.EntityFrameworkCore.DataAccess;
using dotnetQ.Storage.EntityFrameworkCore.DbCtxs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnetQ.AspNetCore._IocConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDotnetQ(this IServiceCollection services, IHostEnvironment environment)
        {
            services.AddDbContext<QDbContext>();

            services.AddScoped<IQManager, QManager>();
            services.AddScoped<IQRepository,QRepository>();
            
            services.AddHostedService<QAggregatorWorker>();
            services.AddHostedService<QPackGenerateWorker>();
            services.AddHostedService<QProcessWorker>();
            services.AddHostedService<QRequeueWorker>();
            services.AddHostedService<QWorkerHealthCheckWorker>();

        }


        public static void UseDotnetQ(this IApplicationBuilder app, 
            IHostEnvironment environment, 
            bool setAsActiveWorker,
            ICollection<ItemType> itemTypes)
        {

            var qRepository = app.ApplicationServices.GetRequiredService<IQRepository>();
            qRepository.AddWorker(new Worker()
            {
                Id = 0,
                HostName = Environment.MachineName,
                ProcessId = Environment.ProcessId,
                IsProduction = environment.IsProduction(),
                LastActivationAt = setAsActiveWorker ? DateTime.Now : null,
                LastDeactivationAt = setAsActiveWorker==false ? DateTime.Now : null,
                IsActive = setAsActiveWorker,
                CreatedAt = DateTime.Now
            }, default);



        }
    }
}
