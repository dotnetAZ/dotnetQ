using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs;
using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer._IocConfig
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDotnetQSqlServerStorage(this IServiceCollection services,
            string primaryDbConnection,
            string? readonlyDbConnection = null)
        {
            // Add Primary Databases
            services.AddDbContextPool<QPrimaryDbContext>(options =>
            {
                options.UseSqlServer(primaryDbConnection);

            }, 256);

            // Add Readonly Databases
            services.AddDbContextPool<QReadonlyDbContext>(options =>
            {
                options.UseSqlServer(readonlyDbConnection ?? primaryDbConnection);
            }, 256);

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
