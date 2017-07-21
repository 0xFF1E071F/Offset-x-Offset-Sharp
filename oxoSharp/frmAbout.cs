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
    public partial class frmAbout : Form
    {
        public frmAbout(bool CheckBox = false)
        {
            InitializeComponent();
            byteMap1.PeHeaderSize = 20;
            byteMap1.SizeOfTheFile = 900;
            byteMap1.startOffset = 200;
            byteMap1.endOffset = 260;
            byteMap1.EOFsize = 10;
            byteMap1.FixedRanges = new int[][] { 
                                                 new int[] { 400, 420 },
                                                 new int[] { 440, 460 },
                                                 new int[] {470,480}
                                                };
            if (CheckBox)
                btnOk.Enabled = false;
            else
            {
                checkBox1.Checked = true;
                checkBox1.Enabled = false;
            }
            this.AcceptButton = btnOk;
        }

        private void frmAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text += GlobalDataAndMethods.VersionAndDate();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            btnOk.Enabled = checkBox1.Checked;
        }
    }
}
