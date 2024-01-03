using dotnetQ.Abstractions.Models;

namespace dotnetQ.Abstractions.Attributes
{
    public class QHandlerAttribute : Attribute
    {
        private readonly int itemTypeId;

        public QHandlerAttribute(int itemTypeId)
        {
            this.itemTypeId = itemTypeId;
        }
    }
}
