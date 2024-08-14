using dotnetQ.Abstractions.Attributes;
using dotnetQ.Abstractions.Storage;

namespace dotnetQ.Abstractions.Services
{
    public interface IPackGeneratorRecurringJob
    {
        Task Execute(QueueEnum queue, CancellationToken cancellationToken);
    }

    public class PackGeneratorRecurringJob : IPackGeneratorRecurringJob
    {
        private readonly IPackRepository _packRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IWorkerRepository _workerRepository;

        public PackGeneratorRecurringJob(
            IPackRepository packRepository,
            IItemRepository itemRepository,
            IWorkerRepository workerRepository)
        {
            _packRepository = packRepository;
            _itemRepository = itemRepository;
            _workerRepository = workerRepository;
        }


        public async Task Execute(QueueEnum queue, CancellationToken cancellationToken)
        {
            switch (queue)
            {
                case QueueEnum.Inbox:
                    break;

                case QueueEnum.InternalQueue:
                    break;

                case QueueEnum.OutboxEvents:
                    break;
            }
        }
    }
}
