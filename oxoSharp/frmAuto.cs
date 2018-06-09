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
using oxoSharp.Interfaces;

namespace oxoSharp
{
    /*
     * disable "Auto process button" on frmMain when "Go" is pressed
     * (done) maybe oxocore needs to become dynamic
     * (done) frmAuto configs added to main configs (ref in constructor)
     * add possiblity to resume
     *      maybe result => use ase default range applies to autprocess and not main windows (makes more sens)
     * continue autporcess.split
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
        private Session _session;
        private IMainForm _parent;
        private AutoProcess _autoProcess;
        private Dictionary<string, Label> _stateLabels = new Dictionary<string, Label>();

        public frmAuto(Session session, IMainForm mainForm)
        {
            InitializeComponent();
            this._session = session;
            this._parent = mainForm;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;

            Width = 558;
            UpdateGUI(true);

            if (!AutoProcess.IsBusy())
                AutoProcess.SetSession(_session.Clone());
            AutoProcess.DoWork();

            UpdateStatus();
            ShowConfig();
        }

        private void ShowConfig()
        {
            string mode =
                AutoProcess.Session.mode.HasFlag(Mode._unknownFromEnd) ? "Unk. from end" :
                AutoProcess.Session.mode.HasFlag(Mode._unknownFromStart) ? "Unk. from start" :
                "Fixed";
            autoprocessflow.SetConfig(mode);

        }

        private void UpdateStatus()
        {
            autoprocessflow.Status(
                GlobalDataAndMethods.OutputFormat(AutoProcess.Session.start),
                GlobalDataAndMethods.OutputFormat(AutoProcess.Session.end),
                GlobalDataAndMethods.OutputFormat(AutoProcess.Session.size)
                );
        }

        private void UpdateGUI(bool starting)
        {
            TopMost = starting;
            btnStop.Visible = starting;
            btnStart.Visible = !starting;
            btnResult.Enabled = !starting;
            btnRestart.Enabled = !starting;
        }

        private void WorkDone(object obj, RunWorkerCompletedEventArgs args)
        {
            UpdateGUI(false);
            ShowResults();
        }
        private void progress(object obj, ProgressChangedEventArgs args)
        {
            progressBar1.Value = args.ProgressPercentage;
        }

        private void frmAuto_Load(object sender, EventArgs e)
        {
            FillGui();
        }

        private void FillGui()
        {
            txtStart.Text = _session.start.ToString("X");
            txtEnd.Text = _session.end.ToString("X");
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
        internal AutoProcess AutoProcess
        {
            get
            {
                if (_autoProcess == null)
                    _autoProcess = new AutoProcess(new ProgressChangedEventHandler(progress), new RunWorkerCompletedEventHandler(WorkDone), StateCallBack, true);
                return _autoProcess;
            }
        }
        #endregion

        private void StateCallBack(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is string state)
            {
                autoprocessflow.SetState(state);
            }
            UpdateStatus();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            ShowResults();
        }

        private void ShowResults()
        {
            using (frmResult result = new frmResult(AutoProcess.Singatures))
                _parent.RangeOptions(result);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            Width = 289;
            btnStart.Enabled = true;
            btnResult.Enabled = false;
            tabControl1.SelectedIndex = 0;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            AutoProcess.StopWork();
            UpdateGUI(false);
        }

        private void frmAuto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AutoProcess.IsBusy())
                e.Cancel = true;
        }
    }
}
