using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oxoSharp.Core;

namespace oxoSharp
{
    /*
     * disable "Auto process button" on frmMain when "Go" is pressed
     * (done) maybe oxocore needs to become dynamic
     * (done) frmAuto configs added to main configs (ref in constructor)
     * 
     */
    public partial class frmAuto : Form
    {
        private const string AutoFixedRangeHalp = "The viral signature is the range last range that was not deleted by the AV\n" +
                                                  "When the viral signature is juged too large (greater than max size) we consider" +
                                                  "that there are more than one, to isolate them (or one of them) we split the undetected" +
                                                  "range to a Variable and a Fixed range, then continue the process. " +
                                                  "When we find the first signature we switch between the two ranges (fix the first, vary the second)," +
                                                  "in order to find the second signature\n" +
                                                  "Auto process feature can do this automatically";
        private Session session;
        private oxoCore _oxoCore;
        public frmAuto(Session session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            AutoProcess auto = new AutoProcess(new ProgressChangedEventHandler(progress), new RunWorkerCompletedEventHandler(WorkDone), true);
            auto.DoWork();
        }

        private void WorkDone(object obj, RunWorkerCompletedEventArgs args)
        {
        }
        private void progress(object obj, ProgressChangedEventArgs args)
        {
        }

        private void frmAuto_Load(object sender, EventArgs e)
        {
            FillGui();
        }

        private void FillGui()
        {
            txtStart.Text = session.start.ToString("X");
            txtEnd.Text = session.end.ToString("X");
            chkUserDefinedRanges.Checked = GlobalDataAndMethods.Config.EnableUserDefinedFixedRange;
            chkSplitSignature.Checked = GlobalDataAndMethods.Config.AutoGenerateFixedRange;
            txtMaxSize.Text = GlobalDataAndMethods.Config.SignatureMaxSize.ToString("X");
            switch (GlobalDataAndMethods.Config.nextRange)
            {
                case NextRange._first:
                    radioFirstResult.Checked = true;
                    break;
                case NextRange._last:
                    radioLastResult.Checked = true;
                    break;
                case NextRange._random:
                    radioRandomResult.Checked = true;
                    break;
            }
        }

        private void btnAutoFixedHelp_Click(object sender, EventArgs e)
        {
            string s = "";
            ShowMessage(s);
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(this, message);
        }

        private void radioNextResult_CheckedChanged(object sender, EventArgs e)
        {
            GlobalDataAndMethods.Config.nextRange = (radioFirstResult.Checked) ? NextRange._first : ((radioLastResult.Checked) ? NextRange._last : NextRange._random);
        }

        private void chkUserDefinedRanges_CheckedChanged(object sender, EventArgs e)
        {
            GlobalDataAndMethods.Config.EnableUserDefinedFixedRange = chkUserDefinedRanges.Checked;
        }

        private void chkSplitSignature_CheckedChanged(object sender, EventArgs e)
        {
            GlobalDataAndMethods.Config.AutoGenerateFixedRange = chkSplitSignature.Checked;
        }

        private void txtMaxSize_TextChanged(object sender, EventArgs e)
        {
            GlobalDataAndMethods.Config.SignatureMaxSize = txtMaxSize.ParseText();
        }
        #region properties
        public oxoCore OxoCore
        {
            get
            {
                if (OxoCore == null)
                    _oxoCore = new oxoCore(new ProgressChangedEventHandler(progress), new RunWorkerCompletedEventHandler(WorkDone));
                return _oxoCore;
            }
        }
        #endregion
    }
}
