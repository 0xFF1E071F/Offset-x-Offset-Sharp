using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;


namespace oxoSharp.UserControls
{
    public partial class ByteMap2 : UserControl
    {
        public Color BackColor1 = Color.FromArgb(0xff, 0x22, 0x22, 0x22);
        public Color BackColor2 = Color.FromArgb(0x60, 0xFF, 0xFF, 0xFF);
        private Brush FullRangeBrush = Brushes.DodgerBlue;
        private Brush SmallRangeBrush = Brushes.Red;
        private Brush PeHeaderBrush = Brushes.Orange;
        private Brush EOFbrush = Brushes.Chartreuse;
        private Brush FixedRangeBrush1 = new SolidBrush(Color.DarkGray);
        private Brush FixedRangeBrush2 = new SolidBrush(Color.LightGray);
        public int GradientHeight = 10;
        public int RectangleSize = 7;

        public int PeHeaderSize = 0;
        public int EOFsize = 0;
        private int _startOffset = 0;
        private int _endOffset = 0;
        private int _SizeOfTheFile = 0;
        private int _SmallRangeWidth = 0;
        public int[][] FixedRanges;

        public Dictionary<RegionType, string> RegionsNames = new Dictionary<RegionType, string>();
        private Point PreviousMouseLocation = new Point(-1, -1);
        private RectangleF[] _rectangles;
        private Dictionary<RectangleF, RegionType> _rectanglesWithRegionType;
        public Dictionary<RegionType, Brush> RegionsBrushes = new Dictionary<RegionType, Brush>();

        public ByteMap2()
        {
            InitializeComponent();
            GenerateRegionNamesDictionary();
            GenerateRegionsBrushesDictionary();
            this.DoubleBuffered = true;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateSize();
            UpdateRectangles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            //DrawBackGround(e.Graphics);
            FillRetangles(e.Graphics);
            DrawGridLines(e.Graphics);
            UpdateSize();
            //DrawBorders(e.Graphics);
        }
        #region Refactored methods
        private void GenerateRegionsBrushesDictionary()
        {
            RegionsBrushes[RegionType.NotSelected] = FullRangeBrush;
            RegionsBrushes[RegionType.Selected] = SmallRangeBrush;
            RegionsBrushes[RegionType.FixedRange1] = FixedRangeBrush1;
            RegionsBrushes[RegionType.FixedRange2] = FixedRangeBrush2;
            RegionsBrushes[RegionType.Header] = PeHeaderBrush;
            RegionsBrushes[RegionType.EOF] = EOFbrush;
        }

        private void GenerateRegionNamesDictionary()
        {
            RegionsNames[RegionType.NotSelected] = "Not selected bytes";
            RegionsNames[RegionType.Selected] = "Selected (variable) range";
            RegionsNames[RegionType.FixedRange1] = "Fixed range";
            RegionsNames[RegionType.FixedRange2] = "Fixed range";
            RegionsNames[RegionType.Header] = "PE header";
            RegionsNames[RegionType.EOF] = "End Of File (overlay)";
        }

        private void UpdateRectangles()
        {
            GenerateRectangles();
            GenerateRectanglesWithRegionType();
        }
        private void UpdateSize()
        {
            this.Width = (this.Width / RectangleSize) * RectangleSize + 1;
            this.Height = (this.Height / RectangleSize) * RectangleSize + 1;
        }
        private void FillRetangles(Graphics g)
        {
            FillBackgroundOfRectangle(g);
            DrawOverlaysOfRectangles(g, Rectangles.Last());
        }

        private void DrawOverlaysOfRectangles(Graphics g, RectangleF LastRectangle)
        {
            for (int i = 0; i < NumberOfRectanglesY(); i++)
                DrawOverlays(g, new RectangleF(0.0f, i * RectangleSize, LastRectangle.X + LastRectangle.Width, LastRectangle.Height));
        }

        private void FillBackgroundOfRectangle(Graphics g)
        {
            for (int i = 0; i < NumberOfrectangles(); i++)
                g.FillRectangle(
                                    RegionsBrushes[RectanglesWithRegionType.ElementAt(i).Value]
                                    , Rectangles[i]
                                );

        }

        private void GenerateRectanglesWithRegionType()
        {
            _rectanglesWithRegionType = new Dictionary<RectangleF, RegionType>();
            int fixedRangeindex = 0;
            for (int i = 0; i < NumberOfrectangles(); i++)
                if (InsideVariableRange(i)) //  Selected interval
                    _rectanglesWithRegionType[Rectangles[i]] = RegionType.Selected;

                else if (InsideFixedRange(i,out fixedRangeindex))
                    _rectanglesWithRegionType[Rectangles[i]] = (fixedRangeindex % 2 == 0) ? RegionType.FixedRange1 : RegionType.FixedRange2;
               
                else if (InsidePeHeader(i)) // PE header
                    _rectanglesWithRegionType[Rectangles[i]] = RegionType.Header;
               
                else if (InsideEOF(i)) // EOF
                    _rectanglesWithRegionType[Rectangles[i]] = RegionType.EOF;
               
                else
                    _rectanglesWithRegionType[Rectangles[i]] = RegionType.NotSelected;
        }

        private bool InsideFixedRange(int i,out int fixedRangeIndex)
        {
            fixedRangeIndex = 0;
            if (FixedRanges != null)
                for (int j = 0; j < FixedRanges.Length; j++)
                {
                    int scaled = ScaleToNumberOfRectangles(FixedRanges[j][0], -1); // Locate the rectangle that matches start address of the range
                    if (FixedRanges[j].Length >= 2 && i >= ScaleToNumberOfRectangles(FixedRanges[j][0], -1) && i <= ScaleToNumberOfRectangles(FixedRanges[j][1]))
                    {
                        fixedRangeIndex = j;
                        return true;
                    }
                }
            return false;
        }

        private bool InsideEOF(int i)
        {
            return EOFfirstByte > 0 && i >= EOFfirstByte;
        }

        private bool InsidePeHeader(int i)
        {
            return i >= 0 && i < PeHeaderLastByte;
        }

        private bool InsideVariableRange(int i)
        {
            return i >= FirstByte && i <= LastByte;
        }

        private void FillRectangle(Graphics g, RectangleF rectangle, Brush brush)
        {
            g.FillRectangle(brush, rectangle);
        }

        private void DrawGridLines(Graphics g)
        {
            g.DrawRectangles(Pens.Black, Rectangles);
        }

        private void GenerateRectangles(/*bool Borders = true*/)
        {
            List<RectangleF> rectangles = new List<RectangleF>();
            for (int i = 0; i < NumberOfRectanglesY(); i++)
            {
                for (int j = 0; j < NumberOfRectanglesX(); j++)
                {
                    rectangles.Add(new RectangleF(j * RectangleSize /*+ (Borders ? 0 : 1)*/, i * RectangleSize /*+ (Borders ? 0 : 1)*/, RectangleSize /*- (Borders ? 0 : 1)*/, RectangleSize /*- (Borders ? 0 : 1)*/));
                }
            }
            _rectangles = rectangles.ToArray();
        }
        private void DrawBorders(Graphics g)
        {
            g.DrawRectangle(Pens.Black, Borders);
        }

        private void DrawOverlays(Graphics g, RectangleF rectangle)
        {
            DrawLightOverlay(g, rectangle);
            DrawDarkOverlay(g, rectangle);
        }

        private void DrawDarkOverlay(Graphics g, RectangleF rectangle)
        {
            g.FillRectangle(
                darkOverlayGradienBrush(rectangle)
                , HalfRectangle(rectangle, false));
        }

        private void DrawLightOverlay(Graphics g, RectangleF rectangle)
        {
            g.FillRectangle(
                overlayGradientBrush(HalfRectangle(rectangle, true))
                , HalfRectangle(rectangle, true));
        }

        private RectangleF HalfRectangle(RectangleF rectangle, bool upper)
        {
            return new RectangleF(rectangle.X, rectangle.Y - 1 + (upper ? 0 : rectangle.Height / 2), rectangle.Width, rectangle.Height / 2);
        }

        private void DrawBackGround(Graphics g)
        {
            g.FillRectangle(new SolidBrush(BackColor1), Borders);

        }
        #endregion


        private int NumberOfrectangles()
        {
            return NumberOfRectanglesX() * NumberOfRectanglesY();
        }
        private int NumberOfRectanglesX()
        {
            return Width / RectangleSize;
        }
        private int NumberOfRectanglesY()
        {
            return Height / RectangleSize;
        }
        private int ScaleToNumberOfRectangles(int value, int defaultValue = 0)
        {
            if (SizeOfTheFile == 0) return defaultValue;
            return value * NumberOfrectangles() / SizeOfTheFile;
        }

        private Rectangle Borders
        {
            get
            {
                return (new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }

        private LinearGradientBrush overlayGradientBrush(RectangleF rectangle)
        {
            return GradienBrush(rectangle, false);
        }
        private LinearGradientBrush darkOverlayGradienBrush(RectangleF rectangle)
        {
            return GradienBrush(rectangle, true);
        }

        private LinearGradientBrush GradienBrush(RectangleF rectangle, bool dark)
        {
            return new LinearGradientBrush(rectangle, dark ? BackColor1 : BackColor2, Color.Transparent, 90.0f);
        }

        private int FirstByte
        {
            get
            {
                return ScaleToNumberOfRectangles(startOffset);
            }
        }
        private int EOFfirstByte
        {
            get
            {
                return ScaleToNumberOfRectangles(SizeOfTheFile - EOFsize);
            }
        }
        private int LastByte
        {
            get
            {
                if (startOffset == endOffset)
                    return -1;

                else
                    return ScaleToNumberOfRectangles(endOffset, -1);
            }
        }
        private int PeHeaderLastByte
        {
            get
            {
                return ScaleToNumberOfRectangles(PeHeaderSize, -1);
            }
        }
        public int startOffset
        {
            get { return _startOffset; }
            set
            {
                _startOffset = value;
            }
        }
        public int endOffset
        {
            get { return _endOffset; }
            set
            {
                _endOffset = value;
            }
        }
        public int SizeOfTheFile
        {
            get { return _SizeOfTheFile; }
            set
            {
                _SizeOfTheFile = value;
            }
        }
        public int SmallRangeWidth
        {
            get
            {
                if (_SmallRangeWidth > FullRangeWidth)
                    return FullRangeWidth;
                else
                    return _SmallRangeWidth;
            }
            set
            {
                _SmallRangeWidth = value;
            }
        }
        private int FullRangeWidth
        {
            get
            {
                return endOffset - startOffset;
            }
        }
        public void ReDraw()
        {
            UpdateRectangles();
            this.Invalidate();
            this.Update();
        }

        private void ByteMap2_MouseMove(object sender, MouseEventArgs e)
        {
            ShowRegionsNameInTooltip(e.Location);
        }

        private void ShowRegionsNameInTooltip(Point location)
        {
            string tooltip;
            if (MouseMoved(location) && RegionFromMouseLocation(location, out tooltip))
                toolTip1.Show(tooltip, this, DisplayLocation(location));
            PreviousMouseLocation = location;
        }

        private Point DisplayLocation(Point location)
        {
            location.Offset(15, 15);
            return location;
        }

        private bool MouseMoved(Point location)
        {
            return (location.X != PreviousMouseLocation.X || location.Y != PreviousMouseLocation.Y);
        }

        private bool RegionFromMouseLocation(Point location, out string tooltip)
        {
            RectangleF rectangle;
            if (GetRectangleAt(location, out rectangle))
            {
                tooltip = RegionsNames[RectanglesWithRegionType[rectangle]];
                return true;
            }
            tooltip = "";
            return false;
        }

        private bool GetRectangleAt(Point location, out RectangleF rectangle)
        {
            rectangle = RectangleF.Empty;

            if (RectanglesWithRegionType != null)
            {
                // this method is faster but it showed some bugs, too lazy to fix, using the bruteforce method
                //int x = location.X / (RectangleSize);
                //int y = location.Y / (RectangleSize);
                //int index = y * NumberOfRectanglesY() + x;
                //if (index >= 0 && index < rectangles.Length)
                //{
                //    rectangle = rectangles[index];
                //    return true;
                //}

                foreach (RectangleF rect in Rectangles)
                {
                    if (rect.X <= location.X && rect.Y <= location.Y && rect.X + rect.Width >= location.X && rect.Y + rect.Height >= location.Y)
                    {
                        rectangle = rect;
                        return true;
                    }
                }
            }
            return false;
        }
        public enum RegionType
        {
            NotSelected = 0,
            Selected,
            FixedRange1,
            FixedRange2,
            Header,
            EOF
        }

        private void ByteMap2_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(this);
        }

        private Dictionary<RectangleF, RegionType> RectanglesWithRegionType
        {
            get
            {
                if (_rectanglesWithRegionType == null)
                    GenerateRectanglesWithRegionType();
                return _rectanglesWithRegionType;
            }
        }

        public RectangleF[] Rectangles
        {
            get
            {
                if (_rectangles == null)
                    GenerateRectangles();
                return _rectangles;
            }
        }
    }

}
