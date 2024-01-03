using dotnetQ.Abstractions.Models;

namespace dotnetQ.Abstractions.Storage
{
    public interface IQRepository
    {

        #region Q-Worker
        Task<ICollection<Worker>> GetAllWorkers(CancellationToken cancellationToken);
        Task<Worker> GetWorker(int workerId, CancellationToken cancellationToken);
        Task<Worker> AddWorker(Worker worker, CancellationToken cancellationToken);
        Task<Worker> SetWorkerActivation(Worker worker, CancellationToken cancellationToken);
        #endregion


        #region Q-ItemTypes
        Task<ICollection<ItemType>> GetAllItemTypes(CancellationToken cancellationToken);
        Task<ItemType> GetItemType(int itemTypeId, CancellationToken cancellationToken);
        Task<ItemType> AddItemType(ItemType itemType, CancellationToken cancellationToken);
        #endregion


        #region Q-Items
        Task<Item> GetItem(int itemId, CancellationToken cancellationToken);
        Task<Item> AddItem(Item item, CancellationToken cancellationToken);
        Task<Item> RemoveItem(int itemId, CancellationToken cancellationToken);
        #endregion

        #region Q-Packs
        #endregion

    }
}
