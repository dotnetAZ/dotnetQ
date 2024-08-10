using dotnetQ.Abstractions.Storage;
using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs;
using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer._IocConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDotnetQSqlServerStorage(this IServiceCollection services, QDbConfigs qDbConfigs)
        {
            // Add Databases Configs
            services.AddSingleton(qDbConfigs);

            // Add Databases (Primary , ReadOnly)
            services.AddDbContext<QPrimaryDbContext>(options => { options.UseSqlServer(qDbConfigs.PrimaryDbConnection); });
            services.AddDbContextPool<QReadonlyDbContext>(options => { options.UseSqlServer(qDbConfigs.ReadonlyDbConnection ?? qDbConfigs.PrimaryDbConnection); }, 256);

            // Add Repositories
            services.AddScoped<IPackRepository, PackRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
        }

        /// <summary>
        /// Database Initializer
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public async static Task DotnetQ_ApplyPendingMigrations(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<QPrimaryDbContext>();
                if ((await db.Database.GetPendingMigrationsAsync()).Any())
                {
                    await db.Database.MigrateAsync();
                }
            }
        }
    }
}
