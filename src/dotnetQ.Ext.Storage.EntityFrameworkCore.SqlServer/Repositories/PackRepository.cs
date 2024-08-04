using dotnetQ.Abstractions.Storage;
using dotnetQ.Storage.EntityFrameworkCore.SqlServer.DbCtxs;

namespace dotnetQ.Storage.EntityFrameworkCore.SqlServer.Repositories;

public class PackRepository : IPackRepository
{
    private readonly QPrimaryDbContext _primaryDbContext;
    private readonly QReadonlyDbContext _readonlyDbContext;

    public PackRepository(
        QPrimaryDbContext primaryDbContext,
        QReadonlyDbContext readonlyDbContext)
    {
        _primaryDbContext = primaryDbContext;
        _readonlyDbContext = readonlyDbContext;
    }

    #region Queries
    #endregion

    #region Commands
    #endregion
}