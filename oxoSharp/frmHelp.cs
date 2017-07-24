using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oxoSharp
{
    public partial class frmHelp : Form
    {
        private Help help;
        public frmHelp(Help help)
        {
            InitializeComponent();
            KeyPreview = true;
            this.help = help;
            lblDescription.Text = help.Description;
            byteMap21.CustomizeRedRangeName("Filled range");
        }

        private void frmHelp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }

        private void frmHelp_Load(object sender, EventArgs e)
        {
            byteMap21.SizeOfTheFile = 5000;
            DisplayFrame(help.First());
            tmrAnimation.Start();
        }

        private void DisplayFrame(Frame frame)
        {
            byteMap21.startOffset = frame.Start;
            byteMap21.endOffset = frame.End;
            byteMap21.ReDraw();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tmrAnimation.Stop();
            Next();
        }

        private void Next()
        {
            DisplayFrame(help.Next());
        }

        private void Previous()
        {
            DisplayFrame(help.Previous());
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            tmrAnimation.Stop();
            Previous();
        }

        private void tmrAnimation_Tick(object sender, EventArgs e)
        {
            Next();
        }

    }
}
