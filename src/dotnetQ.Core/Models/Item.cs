namespace dotnetQ.Core.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string ActionData { get; set; }
        public string? ActionDataHash { get; set; }
        public string? ActionDomainDataHash { get; set; }
        public DateTime ActionAt { get; set; }
        public DateTime CanPackAt { get; set; }
        public bool IsPacked { get; set; }
        public int? RequeueRefItemId { get; set; }
        public int RequeueCount { get; set; }
        public DateTime CreatedAt { get; set; }


        public Type Type { get; set; }
    }
}
