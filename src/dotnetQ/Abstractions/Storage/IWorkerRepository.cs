using dotnetQ.Abstractions.Entities.QWorkers;

namespace dotnetQ.Abstractions.Storage
{
    public interface IWorkerRepository
    {
        #region Queries
        Task<bool> GetWorkerToCheckExistence(Guid serverId, string machineName, int processId, bool isProduction);
        Task<List<Worker>> GetListOfActiveWorkers(bool isProduction);
        Task<Worker> GetActivationStatus(Guid serverId);
        #endregion

        #region Commands
        Task AddWorker(Worker model);
        Task SetWorkerHeartBeat(Guid serverId, string machineName, int processId, bool isProduction);
        Task<List<Worker>> TerminateInactiveWorkers(int inActiveTimeFromMinute);
        #endregion
    }
}
