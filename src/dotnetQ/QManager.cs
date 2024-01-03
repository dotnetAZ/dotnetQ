using dotnetQ.Abstractions.Models;
using dotnetQ.Abstractions.Services;
using dotnetQ.Abstractions.Storage;
using System.Threading;

namespace dotnetQ
{
    public class QManager : IQManager
    {
        private readonly IQRepository _qRepository;

        public QManager(IQRepository qRepository)
        {
            this._qRepository = qRepository;
        }

        public async Task<Item> AddItem(Item item, CancellationToken cancellationToken)
        {
            return await _qRepository.AddItem(item, cancellationToken);
        }

        public async Task<Item> RemoveItem(int itemId, CancellationToken cancellationToken)
        {
            return await _qRepository.RemoveItem(itemId, cancellationToken);
        }
    }
}
