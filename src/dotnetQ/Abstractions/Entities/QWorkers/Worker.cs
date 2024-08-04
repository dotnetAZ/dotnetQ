namespace dotnetQ.Abstractions.Entities.QWorkers;

public class Worker
{
    #region Attributes
    public int Id { get; set; }
    public Guid ServerId { get; set; }
    public string MachineName { get; set; }
    public int ProcessId { get; set; }
    public bool IsProduction { get; set; }

    public bool IsActive { get; set; }

    public DateTime RegisteredAt { get; set; }
    public DateTime? LastHeartbeatAt { get; set; }
    public bool IsTerminated { get; set; }
    public DateTime? TerminatedAt { get; set; }
    #endregion



    #region Factories

    public static Worker AddWorker(Guid serverId, string machineName, int processId, bool isProduction)
    {
        return new Worker
        {
            ServerId = serverId,
            MachineName = machineName,
            ProcessId = processId,
            IsProduction = isProduction,
            RegisteredAt = DateTime.Now,
            IsActive = true,
            IsTerminated = false,
        };
    }
    #endregion
}
