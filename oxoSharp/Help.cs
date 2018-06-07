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

        public int Start, End, Size;

        int _index = 0;
        Frame[] Frames = new Frame[] { }; // init to avoid bugs
        public string Description;

        public Help(int Start, int End, int Size, Mode mode, string Description)
        {
            this.Start = Start;
            this.End = End;
            this.Size = Size;

            this.Description = Description;
            int NumberOfFrames = (End - Start) / Size;

            Frames = new Frame[NumberOfFrames];


            FrameGenerator frameGenerator = FrameGenerator.GetGenerator(mode).Init(Start, End, Size);
            for (int i = 0; i < NumberOfFrames; i++)
                Frames[i] = frameGenerator.GenerateNext();
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
                    _index = Frames.Length - 1;
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
    internal abstract class FrameGenerator
    {
        static FixedModeGenerator genFixed = new FixedModeGenerator();
        static UnknownFromEnd genUnkEnd = new UnknownFromEnd();
        static UnknownFromStart genUnkStart = new UnknownFromStart();

        public static FrameGenerator GetGenerator(Mode mode)
        {
            if (mode.HasFlag(Mode._unknownFromStart))
                return genUnkStart;
            else if (mode.HasFlag(Mode._unknownFromEnd))
                return genUnkEnd;
            else
                return genFixed;
        }

        protected int _start, _end, _size, _currentStart, _currentEnd;

        public virtual FrameGenerator Init(int start, int end, int size)
        {
            _start = start;
            _end = end;
            _size = size;
            _currentEnd = end;
            _currentStart = start;
            return this;
        }
        public abstract Frame GenerateNext();

        public class FixedModeGenerator : FrameGenerator
        {
            public override Frame GenerateNext()
            {
                if (_currentStart >= _end)
                    _currentStart = _end;

                _currentEnd = _currentStart + _size;
                if (_currentEnd > _end)
                    _currentEnd = _end;

                Frame frame = new Frame(_currentStart, _currentEnd);
                _currentStart += _size;
                return frame;
            }
        }

        private class UnknownFromEnd : FrameGenerator
        {
            public override Frame GenerateNext()
            {
                Frame frame = new Frame(_start, _currentEnd);

                _currentEnd -= _size;
                if (_currentEnd < _start)
                    _currentEnd = _start;

                return frame;
            }
        }

        private class UnknownFromStart : FrameGenerator
        {
            public override Frame GenerateNext()
            {
                Frame frame = new Frame(_currentStart, _end);

                _currentStart += _size;
                if (_currentStart > _end)
                    _currentStart = _end;
                return frame;
            }
        }
    }
}
