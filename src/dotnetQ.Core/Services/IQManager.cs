using dotnetQ.Abstractions.Models;

namespace dotnetQ.Abstractions.Services
{
    public interface IQManager
    {
        public void AddItem(Item item);
        public void RemoveItem();

    }
}
