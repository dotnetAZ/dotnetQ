namespace dotnetQ.Core.Entities
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Title { get; set; } // ?
        public bool IsProcessable { get; set; }
        public int Weight { get; set; }
        public int PackSize { get; set; }
        public bool IsRetriable { get; set; }
        public byte MaxRetries { get; set; }
        public int CanProccessAfterMin { get; set; }
        public DateTime CreatedAt { get; set; }


        public ICollection<Item> Items { get; set; }
        public ICollection<Pack> Packs { get; set; }
    }
}
