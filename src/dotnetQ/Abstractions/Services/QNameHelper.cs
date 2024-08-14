using dotnetQ.Abstractions.Attributes;

namespace dotnetQ.Abstractions.Services
{
    public static class QNameHelper
    {
        public static string PickAndReleaseJob = "_Pick_And_Release_";

        public static string GetQueueName(string machineName) => machineName;
        public static string GetQueueName(string machineName, int processId) => machineName + "_" + processId;

        public static string PackGeneratorRecurringJob(this QueueEnum type) => $"{type}_Generate_Packs";

        // "Inbox_Pick_And_Release_"
        public static string PickAndReleaseRecurringJob(this QueueEnum type, string machineName, int processId) => $"{type}{PickAndReleaseJob}{machineName}_{processId}";
        public static string RequeueExceptionsRecurringJobName(this QueueEnum type) => $"{type}_ReQueue_Exceptions";
        public static string DeleteOldItemsAndCreateStatisticsRecurringJobName(this QueueEnum type) => $"{type}_Delete_OldItems_And_CreateStatistics";
        public static string AssignNewServersToAbandonedPacksRecurringJobName(this QueueEnum type) => $"{type}_Assign_NewServers_To_Abandoned_Packs";
    }
}
