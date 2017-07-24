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
    public partial class frmAddRange : Form
    {
        private int Start;
        private int End;

        public int[] Range
        {
            get
            {
                return new int[] { Start, End };
            }
        }

        public frmAddRange(string WindowTitle, string Start, string End)
        {
            InitializeComponent();
            this.AcceptButton = btnOk;
            this.Text = WindowTitle;
            txtStart.Text = Start;
            txtEnd.Text = End;
            this.KeyPreview = true;
        }
        public frmAddRange(string WindowTitle, int[] Range): this(WindowTitle,Range[0].ToString("X"),Range[1].ToString("X"))
        {

        }
        public frmAddRange(string WindowTitle):this(WindowTitle,"","")
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtStart.ParseText(out Start) && txtEnd.ParseText(out End))
            {
                if (Start < End)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                    txtStart.Flash();

            }
            else MessageBox.Show("I couldn't parse text, only hex values are accepted");
        }

        private void frmAddRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 27)
                this.Close();
        }
    }
}
