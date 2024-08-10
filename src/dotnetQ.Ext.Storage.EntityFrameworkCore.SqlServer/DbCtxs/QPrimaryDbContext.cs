using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer._IocConfig;
using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs;

public class QPrimaryDbContext : QAbstractDbContext
{
    private readonly QDbConfigs _qConfigs;

    public QPrimaryDbContext(DbContextOptions<QPrimaryDbContext> options, QDbConfigs qConfigs) : base(options)
    {
        _qConfigs = qConfigs;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema(_qConfigs.DefaultSchema);
    }
}