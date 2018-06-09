using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    public class MyList<T> : List<T>
    {
        public event Action ModifiedListEventHandler;

        new public void Add(T item)
        {
            base.Add(item);
            ModifiedListEventHandler();
        }
        new public void AddRange(IEnumerable<T> collection)
        {
            base.AddRange(collection);
            ModifiedListEventHandler();
        }
        new public void Clear()
        {
            base.Clear();
            ModifiedListEventHandler();
        }
        new public void Remove(T item)
        {
            base.Remove(item);
            ModifiedListEventHandler();
        }
    }
}
