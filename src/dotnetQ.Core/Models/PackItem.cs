namespace dotnetQ.Core.Entities
{
    public class PackItem
    {
        public int Id { get; set; }
        public int PackId { get; set; }
        public int ItemId { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseAt { get; set; }
        public bool HasException { get; set; }
        public bool IsRequeued { get; set; }
        public string? ExceptionTrace { get; set; }
        public string? ExceptionMessage { get; set; }
        public DateTime CreatedAt { get; set; }


        public Pack Pack { get; set; }
    }
}
