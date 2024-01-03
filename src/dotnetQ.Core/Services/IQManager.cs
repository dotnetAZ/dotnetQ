using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotnetQ.Core.Entities;

namespace dotnetQ.Core.Services
{
    public interface IQManager
    {
        public void AddItem(Item item);
        public void RemoveItem();

    }
}
