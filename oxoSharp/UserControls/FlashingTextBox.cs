using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace oxoSharp.UserControls
{
    public partial class FlashingTextBox : TextBox
    {
        BackgroundWorker flashWorker = new BackgroundWorker() { WorkerSupportsCancellation = true };

        public FlashingTextBox()
        {
            InitializeComponent();
            flashWorker.DoWork += flashWorker_DoWork;
        }

        public void Flash()
        {
            if (!flashWorker.IsBusy)
                flashWorker.RunWorkerAsync();
        }
        private void flashWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Color original = this.BackColor;
            for (int i = 0; i < FlashTimes; i++)
            {
                SetColor(FlashColor);
                SetColor(original);
            }
        }
        private void SetColor(Color c)
        {
            this.Invoke(new Action(() =>
            {
                this.BackColor = c;
            }));
            Thread.Sleep(FlashDelay);
        }

        private Color _flashColor = Color.Red;
        private int _flashTimes = 3;
        private int _flashDelay = 100;
        public Color FlashColor
        {
            get
            {
                return _flashColor;
            }
            set { _flashColor = value; }
        }
        [DefaultValue(3)]
        public int FlashTimes
        {
            get { return _flashTimes; }
            set
            {
                _flashTimes = value;
            }
        }
        [DefaultValue(100)]
        public int FlashDelay
        {
            get { return _flashDelay; }
            set
            {
                _flashDelay = value;
            }
        }
    }
}
