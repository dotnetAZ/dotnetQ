using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetQ.Core.Entities;
using dotnetQ.Core.Services;
using Microsoft.AspNetCore.Builder;
using dotnetQ.Core.Scheduler;

namespace dotnetQ._IocConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDotnetQ(this IServiceCollection services)
        {
            services.AddScoped<IQManager, QManager>();
            
            services.AddHostedService<QAggregatorWorker>();
            services.AddHostedService<QPackGenerateWorker>();
            services.AddHostedService<QProcessWorker>();
            services.AddHostedService<QRequeueWorker>();
        }


        public static void UseDotnetQ(this IApplicationBuilder builder, ICollection<ItemType> itemTypes)
        {

        }
    }
}
