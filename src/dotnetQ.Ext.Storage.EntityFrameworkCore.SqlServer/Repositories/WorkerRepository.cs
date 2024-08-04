using dotnetQ.Abstractions.Entities.QWorkers;
using dotnetQ.Abstractions.Storage;
using dotnetQ.Storage.EntityFrameworkCore.SqlServer.DbCtxs;
using Microsoft.EntityFrameworkCore;

namespace dotnetQ.Storage.EntityFrameworkCore.SqlServer.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly QPrimaryDbContext _primaryDbContext;
        private readonly QReadonlyDbContext _readonlyDbContext;

        public WorkerRepository(
            QPrimaryDbContext primaryDbContext,
            QReadonlyDbContext readonlyDbContext)
        {
            _primaryDbContext = primaryDbContext;
            _readonlyDbContext = readonlyDbContext;
        }

        #region Queries
        public async Task<bool> GetWorkerToCheckExistence(Guid serverId, string machineName, int processId, bool isProduction)
        {
            return true;
        }

        public async Task<List<Worker>> GetListOfActiveWorkers(bool isProduction)
        {
            return null;
        }

        public async Task<Worker> GetActivationStatus(Guid serverId)
        {
            return null;
        }
        #endregion

        #region Commands
        public async Task AddWorker(Worker model)
        {
            await _primaryDbContext.Workers.AddAsync(model);
            await _primaryDbContext.SaveChangesAsync();
        }

        public async Task SetWorkerHeartBeat(Guid serverId, string machineName, int processId, bool isProduction)
        {
            await _primaryDbContext
                .Workers
                .Where(x => x.ServerId == serverId && !x.IsTerminated && x.ProcessId == processId && x.IsProduction == isProduction)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.LastHeartbeatAt, DateTime.Now));
        }

        public async Task<List<Worker>> TerminateInactiveWorkers(int inActiveTimeFromSeconds)
        {
            var checkTime = DateTime.Now.AddSeconds(-1 * inActiveTimeFromSeconds);

            var inActiveWorkers = await _primaryDbContext.Workers
                .Where(x =>
                    x.IsTerminated == false &&
                    ((x.LastHeartbeatAt != null && x.LastHeartbeatAt < checkTime) || (x.LastHeartbeatAt == null && x.RegisteredAt < checkTime))
                ).ToListAsync();

            foreach (var worker in inActiveWorkers)
            {
                worker.IsTerminated = true;
                worker.IsActive = false;
                worker.TerminatedAt = DateTime.Now;
            }

            await _primaryDbContext.SaveChangesAsync();
            return inActiveWorkers;
        }

        #endregion

    }
}
