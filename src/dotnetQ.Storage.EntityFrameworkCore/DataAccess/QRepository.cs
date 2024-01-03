using dotnetQ.Abstractions.Models;
using dotnetQ.Abstractions.Storage;
using dotnetQ.Storage.EntityFrameworkCore.DbCtxs;

namespace dotnetQ.Storage.EntityFrameworkCore.DataAccess
{
    public class QRepository : IQRepository
    {
        private readonly QDbContext _dbContext;

        public QRepository(QDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region Q-Worker
        public async Task AddQWorker(Worker worker)
        {
            await _dbContext.Workers.AddAsync(worker);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region Q-ItemTypes
        #endregion

        #region Q-Items
        #endregion

        #region Q-Packs
        #endregion
    }
}
