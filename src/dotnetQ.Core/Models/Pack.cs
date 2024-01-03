namespace dotnetQ.Core.Entities
{
    public class Pack
    {
        public int Id { get; set; }
        public int ItemTypeId { get; set; }
        public bool IsPicked { get; set; }
        public DateTime? PickedAt { get; set; }
        public string? ServerName { get; set; }
        public int? WorkerId { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleasedAt { get; set; }
        public DateTime CreatedAt { get; set; }


        public ItemType Type { get; set; }
        public ICollection<PackItem> PackItems { get; set; }
    }
}
