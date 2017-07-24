using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    class MyList<T> : List<T>
    {
        public event Action ModifiedListEventHandler;

        public void Add(T item)
        {
            base.Add(item);
            ModifiedListEventHandler();
        }
        public void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            ModifiedListEventHandler();
        }
        public void Clear()
        {
            base.Clear();
            ModifiedListEventHandler();
        }
        public void Remove(T item)
        {
            base.Remove(item);
            ModifiedListEventHandler();
        }
    }
}
