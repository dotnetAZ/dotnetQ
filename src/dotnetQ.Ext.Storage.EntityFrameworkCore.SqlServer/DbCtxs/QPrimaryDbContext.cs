using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs;

public class QPrimaryDbContext : QAbstractDbContext
{
    public QPrimaryDbContext(DbContextOptions<QPrimaryDbContext> options) : base(options)
    {
    }
}