using dotnetQ.Storage.EntityFrameworkCore.SqlServer.DbCtxs.Abstract;
using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Storage.EntityFrameworkCore.SqlServer.DbCtxs;

public class QPrimaryDbContext : QAbstractDbContext
{
    public QPrimaryDbContext(DbContextOptions<QPrimaryDbContext> options) : base(options)
    {
    }
}