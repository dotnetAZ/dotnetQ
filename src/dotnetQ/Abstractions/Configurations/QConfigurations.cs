﻿namespace dotnetQ.Abstractions.Configurations
{
    public class QConfigurations
    {
        public QWorkerConfig Worker { get; set; }
        public string PackGeneratorCron { get; set; }
        public string PickAndReleaseCron { get; set; }

        //public int GeneratePackPickSize { get; set; } 
        //public string RequeueExceptionedItemsCron { get; set; } 
        //public string RetentionPolicyCron { get; set; } 
        //public string AssignServerToAbandonPacksCron { get; set; } 
        //public QMonitoringConfig Monitoring { get; set; }
    }


    public class QWorkerConfig
    {
        public int HeartbeatIntervalInSeconds { get; set; }
        public int TerminationIntervalInSeconds { get; set; }
    }

    //public class QMonitoringConfig
    //{
    //    public string RemoveUnusedRecurringJobsCron { get; set; }
    //}
}
