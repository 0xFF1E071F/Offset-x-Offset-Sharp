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

namespace oxoSharp
{
    public partial class ByteMap : UserControl
    {
        public Color BackColor1 = Color.FromArgb(0xff, 0x22, 0x22, 0x22);
        public Color BackColor2 = Color.FromArgb(0x60, 0xFF, 0xFF, 0xFF);
        public Brush FullRangeBrush = Brushes.DodgerBlue;
        public Brush SmallRangeBrush = Brushes.Red;
        public int GradientHeight = 10;

        private int _startOffset = 0;
        private int _endOffset = 0;
        private int _SizeOfTheFile = 0;
        private int _SmallRangeWidth = 0;

        public ByteMap()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            DrawBackGround(e.Graphics);
            DrawFullRange(e.Graphics);
            DrawSmallRange(e.Graphics);
            DrawOverlays(e.Graphics);
            DrawBorders(e.Graphics);
        }

        #region Refactored methods
        private void DrawBorders(Graphics g)
        {
            g.DrawRectangle(Pens.Black, Borders);
        }

        private void DrawOverlays(Graphics g)
        {
            g.FillRectangle(overlayGradientBrush, Borders);
            g.FillRectangle(backgroundGradientBrush, LowerGradientRectange);
        }

        private void DrawBackGround(Graphics g)
        {
            g.FillRectangle(new SolidBrush(BackColor1), Borders);

        }
        private void DrawFullRange(Graphics g)
        {
            g.FillRectangle(FullRangeBrush, FullRange);
        }
        private void DrawSmallRange(Graphics g)
        {
            g.FillRectangle(SmallRangeBrush, SmallRange);
        }
        #endregion
        private float ScaleToWidth(float value)
        {
            float scaled;
            if (SizeOfTheFile == 0)
                scaled = 0.0f;
            else
            {
                scaled = value * (float)Width / (float)SizeOfTheFile;
                if (scaled <= 0)
                    scaled = 0.0f;
            }
            return scaled;
        }

        private RectangleF SmallRange
        {
            get
            {
                return new RectangleF(ScaleToWidth(startOffset), 0.0f, ScaleToWidth(SmallRangeWidth), (float)this.Width);
            }
        }
        private RectangleF FullRange
        {
            get
            {
                return new RectangleF(ScaleToWidth(startOffset), 0.0f, ScaleToWidth((float)FullRangeWidth), (float)Height);
            }
        }
        private Rectangle Borders
        {
            get
            {
                return (new Rectangle(0, 0, Width - 1, Height - 1));
            }
        }
        private Rectangle LowerGradientRectange
        {
            get
            {
                return new Rectangle(0, Height - GradientHeight, Width, GradientHeight);
            }
        }
        private LinearGradientBrush backgroundGradientBrush
        {
            get
            {
                return new LinearGradientBrush(LowerGradientRectange, BackColor1, Color.Transparent, 90.0f);
            }
        }
        private LinearGradientBrush overlayGradientBrush
        {
            get
            {
                return new LinearGradientBrush(Borders, BackColor2, Color.Transparent, 90.0f);
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
        public int FullRangeWidth
        {
            get
            {
                return endOffset - startOffset;
            }
        }
        public void ReDraw()
        {
            this.Invalidate();
            this.Update();
        }
    }
}
