using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer.DbCtxs;

public class QReadonlyDbContext : QAbstractDbContext
{
    public QReadonlyDbContext(DbContextOptions<QReadonlyDbContext> options) : base(options)
    {
    }
}