using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace oxoSharp
{
    public class Session
    {
        public int start;
        public int end;
        public int size;
        public string fileLocation;
        [XmlIgnore]
        public Mode mode;
        public int value;
        public string output;
        public List<int[]> UserDefinedFixedRanges;
        [XmlIgnore]
        public List<int[]> AutoAddedFixedRanges = new List<int[]>();

        public Session Clone()
        {
            return new Session()
            {
                start = this.start,
                end = this.end,
                size = this.size,
                fileLocation = this.fileLocation,
                mode = this.mode,
                value = this.value,
                output = this.output,
                UserDefinedFixedRanges = this.UserDefinedFixedRanges.ToList()
            };
        }

        [XmlElement("mode")]
        public int ModeAsInt
        {
            get { return (int)mode; }
            set { mode = (Mode)value; }
        }

        public int[][] AllFixedRanges
        {
            get
            {
                return UserDefinedFixedRanges.Union(AutoAddedFixedRanges).ToArray(); ;
            }
        }

        public int Size
        {
            get { return (size == 0) ? 1 : size; }
            set
            {
                size = value;
                if (size == 0)
                    size = 1;
            }
        }

        public void SetFixedRangesWithoutCollisionWithVariableRange(List<int[]> UserDefinedFixedRanges)
        {
            this.UserDefinedFixedRanges = NoCollisionRanges(UserDefinedFixedRanges);
        }
        public void SetAutoAddedFixedRangesWithoutCollisionWithVariableRange(List<int[]> AutoAddedFixedRanges)
        {
            this.AutoAddedFixedRanges = NoCollisionRanges(AutoAddedFixedRanges);
        }

        public bool isEmpty()
        {
            return !(start != 0 || end != 0 || fileLocation != "" || (UserDefinedFixedRanges != null && UserDefinedFixedRanges.Count > 0));
        }
        private List<int[]> NoCollisionRanges(List<int[]> FixedRanges)
        {
            List<int[]> newRanges = new List<int[]>();
            foreach (int[] range in FixedRanges)
                newRanges.AddRange(ExtractRanges(range));
            return newRanges;
        }
        private List<int[]> ExtractRanges(int[] range)
        {
            List<int[]> ExtractedRanges = new List<int[]>();
            int[] TempRange = new int[2];

            if (!RangeIncludedInVariableRange(range))
                if (RangeEntirelyOutsideVariableRange(range))
                    ExtractedRanges.Add(range);
                else // variable range is partially or entirely inside fixed range
                    ExtractedRanges.AddRange(OuterRanges(range));
            return ExtractedRanges;
        }

        private int[][] OuterRanges(int[] range)
        {
            return (from r in (new int[][] { new int[] { range[0], this.start }, new int[] { this.end, range[1] } })
                    where r[0] < r[1]
                    select r).ToArray();
        }

        public bool RangeEntirelyOutsideVariableRange(int[] range)
        {
            return range[1] <= this.start || range[0] >= this.end;
        }

        public bool RangeIncludedInVariableRange(int[] range)
        {
            return range[0] >= this.start && range[1] <= this.end;
        }

        public bool RangePartiallyIncludedInVariableRange(int[] range)
        {
            // included and not equal
            return RangeIncludedInVariableRange(range) && !RangeEqualsVariableRange(range);
        }

        public bool RangeEqualsVariableRange(int[] range)
        {
            return range[0] == this.start && range[1] == this.end;
        }

        internal void AutoCalculateSize()
        {
            Size = GlobalDataAndMethods.AutoCalculateSize(start, end);
        }
    }
}
