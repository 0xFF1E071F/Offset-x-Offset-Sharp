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
    public partial class frmConfig : Form
    {
        public Config config;
        private bool FlashTxtAv;
        public frmConfig(Config config,bool FlashTxtAv = false)
        {
            InitializeComponent();
            this.config = config;
            this.FlashTxtAv = FlashTxtAv;
        }

        private void frmConfig_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            SetConfigToGUI();
            if (FlashTxtAv)
                txtAV.Flash();
        }

        private void SetConfigToGUI()
        {
            chkAutoDetectPE.Checked = config.AutoDetectPE;
            chkAutoReload.Checked = config.ReloadLastSessionOnStartup;
            chkAutoSave.Checked = config.AutoSaveSessionOnExit;
            chkReinitSessionOnLoad.Checked = config.ReinitSessionOnFileLoad;
            txtDivider.Text = config.SizeDivider.ToString("X");
            txtAV.Text = config.AV_File;
            txtCmdln.Text = config.AV_CommandLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReadConfigFromGUI();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void ReadConfigFromGUI()
        {
            config.AutoDetectPE = chkAutoDetectPE.Checked;
            config.ReloadLastSessionOnStartup = chkAutoReload.Checked;
            config.AutoSaveSessionOnExit = chkAutoSave.Checked;
            config.ReinitSessionOnFileLoad = chkReinitSessionOnLoad.Checked;
            config.SizeDivider = txtDivider.ParseText();
            config.AV_File = txtAV.Text;
            config.AV_CommandLine = txtCmdln.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtAV.Text = openFileDialog1.FileName;
        }
    }
}
