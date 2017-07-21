using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oxoSharp
{
    public class Help
    {
        private const string FixedRangeDescription = "Each loop the interval moves to \"ActaulStartAddress + Size\"";
        private const string VariableRangeFromStartDescription = "Each loop the start address moves to \"ActualStartAddress + Step\", the end address is fixed, the size is calculated accordingly.";
        private const string VariableRangeFromEndDescription = "Each loop the end address moves to \"ActualEndAddress - Step\", the start address is fixed, the size is calculated accordingly.";

        public static Help Fixed = new Help(Mode._normal, FixedRangeDescription);
        public static Help UnkSizeFromStart = new Help(Mode._unknownFromStart, VariableRangeFromStartDescription);
        public static Help UnkSizeFromEnd = new Help(Mode._unknownFromEnd, VariableRangeFromEndDescription);

        int _index = 0;
        Frame[] Frames = new Frame[] { }; // init to avoid bugs
        public string Description;

        public Help(int Start, int End, int Size, Mode mode,string Description)
        {

            this.Description = Description;
            int NumberOfFrames = (End - Start) / Size;
            Frames = new Frame[NumberOfFrames];

            int currentStart = Start;
            int currentEnd = End;

            for (int i = 0; i < NumberOfFrames; i++)
            {
                if (mode.HasFlag(Mode._unknownFromStart))
                {
                    Frames[i] = new Frame(currentStart, End);

                    currentStart += Size;
                    if (currentStart > End)
                        currentStart = End;
                }
                else if (mode.HasFlag(Mode._unknownFromEnd))
                {
                    Frames[i] = new Frame(Start, currentEnd);

                    currentEnd -= Size;
                    if (currentEnd < Start)
                        currentEnd = Start;
                }
                else
                {
                    currentEnd = currentStart + Size;
                    if (currentEnd > End)
                        currentEnd = End;

                    Frames[i] = new Frame(currentStart, currentEnd);
                    currentStart += Size;
                }
            }
        }
        public Help(Mode mode, string Description)
            : this(100, 4000, 100, mode, Description)
        {

        }

        public Frame Next()
        {
            index++;
            return Frames[index];
        }
        public Frame Previous()
        {
            index--;
            return Frames[index];
        }
        public Frame First()
        {
            return Frames[0];
        }
        public int index
        {
            get
            {
                //if (_index >= Frames.Length)
                //    _index = 0;
                //else if (_index < 0)
                //    _index = Frames.Length;
                return _index;
            }
            set
            {
                _index = value;
                if (_index >= Frames.Length)
                    _index = 0;
                else if (_index < 0)
                    _index = Frames.Length-1;
            }
        }
    }

    public class Frame
    {
        public int Start;
        public int End;
        public Frame(int Start, int End)
        {
            this.Start = Start;
            this.End = End;
        }
    }
}
