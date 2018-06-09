using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    internal class History
    {
        List<Entry> _entries = new List<Entry>();

        public History()
        {

        }


        internal Entry[] Entries
        {
            get { return _entries.ToArray(); }
        }
    }
    internal class Entry
    {
        int[][] _results;
        int[] _usedinterval;

        public Entry(int[] usedinterval, ICollection<int[]> results)
        {
            _results = results.ToArray();
            _usedinterval = usedinterval;
        }

        public int[][] Results { get { return _results; } }
        public int[] Usedinterval { get { return _usedinterval; } }
    }
}