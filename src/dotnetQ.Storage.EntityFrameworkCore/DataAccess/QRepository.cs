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

        public Task<Item> AddItem(Item item, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ItemType> AddItemType(ItemType itemType, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }


        #region Q-Worker
        public Task<Worker> GetWorker(int workerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Worker>> GetAllWorkers(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task AddQWorker(Worker worker)
        {
            await _dbContext.Workers.AddAsync(worker);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Worker> SetWorkerActivation(Worker worker, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Worker> AddWorker(Worker worker, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Q-ItemTypes
        public Task<ICollection<ItemType>> GetAllItemTypes(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ItemType> GetItemType(int itemTypeId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Q-Items
        public Task<Item> GetItem(int itemId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        public Task<Item> RemoveItem(int itemId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion


        #region Q-Packs
        #endregion
    }
}
