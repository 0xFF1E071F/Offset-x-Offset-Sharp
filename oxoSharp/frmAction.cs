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
    public partial class frmAction : Form
    {
        public static frmAction frmRangeAction = new frmAction("Default range",
                                                               "Add to fixed ranges",
                                                               "Cancel");
        public static frmAction frmAdvancedCopy = new frmAction("Copy start",
                                                                "Copy end",
                                                                "Copy size");

        public ThreeButtonsWindowAction action;
        public frmAction(string Text1, string Text2, string Text3)
        {
            InitializeComponent();
            this.AcceptButton = btnFirst;
            this.KeyPreview = true;
            btnFirst.Text = Text1;
            btnSecond.Text = Text2;
            btnThird.Text = Text3;
        }

        private void btns_Click(object sender, EventArgs e)
        {
            action = (ThreeButtonsWindowAction)(sender as Control).Tag;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void frmRangeAction_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                Close();
        }

        private void frmAction_Load(object sender, EventArgs e)
        {
           this.DialogResult = System.Windows.Forms.DialogResult.None;
        }
    }
}
