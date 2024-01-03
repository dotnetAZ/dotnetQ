using dotnetQ.Abstractions.Models;

namespace dotnetQ.Abstractions.Services
{
    public interface IQManager
    {
        public Task<Item> AddItem(Item item, CancellationToken cancellationToken);
        public Task<Item> RemoveItem(int itemId, CancellationToken cancellationToken);

    }
}
