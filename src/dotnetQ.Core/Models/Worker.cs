namespace dotnetQ.Abstractions.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string HostName { get; set; }
        public int ProcessId { get; set; }
        public bool IsProduction { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastActivationAt { get; set; }
        public DateTime? LastDeactivationAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
