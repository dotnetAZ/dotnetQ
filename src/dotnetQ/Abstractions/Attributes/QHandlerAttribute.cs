namespace dotnetQ.Abstractions.Attributes
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class QHandlerAttribute : Attribute
    {
        public readonly int ItemType;
        public readonly QueueEnum QueueType;

        public QHandlerAttribute(
            QueueEnum queueType, int itemType
        )
        {
            QueueType = queueType;
            ItemType = itemType;
        }
    }
}
