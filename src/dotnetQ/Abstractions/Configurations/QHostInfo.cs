namespace dotnetQ.Abstractions.Configurations
{
    public sealed class QHostInfo
    {
        public string MachineName { get; set; }
        public string EnvironmentName { get; set; }
        public bool IsProduction => string.IsNullOrEmpty(EnvironmentName) || EnvironmentName.ToLower() == "production";
        public int ProcessId { get; set; }
        public Guid ServerSessionId { get; set; }
    }
}
