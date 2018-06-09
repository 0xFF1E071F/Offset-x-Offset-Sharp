using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oxoSharp.Interfaces;

namespace oxoSharp
{
    public partial class frmSections : Form, IIntervalForm
    {

        private SectionInfo[] sections;

        public int Start = -1;
        public int End = -1;
        public ThreeButtonsWindowAction Action = ThreeButtonsWindowAction._ThirdButton;
        public int[] SelectedInterval;

        public frmSections(PEinfo info)
        {
            InitializeComponent();
            this.sections = info.Sections;
        }

        private void InitListView()
        {
            int i = 1;
            listView1.Items.AddRange(
                (from section in sections
                 select new ListViewItem(new string[]{
                        (i++).ToString(),
                        section.SectionName, 
                        section.RawAddress.ToString("X"),
                        section.RawSize.ToString("X"), 
                        section.ContainsCode.ToString() 
                        }) { BackColor = section.ContainsCode ? Color.LawnGreen : Color.FromName("Window") }).ToArray());

        }

        private void frmSections_Load(object sender, EventArgs e)
        {
            InitListView();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listView1.SelectedItems.Count > 0)
            {
                int min = MinIndex();
                int max = MaxIndex();

                FixSelection(min, max);
                UpdateRange(min, max);
                EnableButton();
            }
        }

        private void UpdateRange(int min, int max)
        {
            Start = sections[min].RawAddress;
            End = sections[max].RawAddress + sections[max].RawSize;
            txtStart.Text = Start.ToString("X");
            txtEnd.Text = End.ToString("X");

        }

        private void EnableButton()
        {
            btnSelect.Enabled = true;
        }

        private void FixSelection(int min, int max)
        {
            for (int i = min + 1; i < max; i++)
            {
                listView1.Items[i].Selected = true;
            }
        }

        private int MaxIndex()
        {
            return listView1.SelectedItems[listView1.SelectedItems.Count - 1].Index;
        }

        private int MinIndex()
        {
            return listView1.SelectedItems[0].Index;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAction();
        }

        private void CloseWithOK()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            SelectedInterval = new int[] { Start, End };
            Close();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            SelectAction();
        }
        private void SelectAction()
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (frmAction.frmRangeAction.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                if (frmAction.frmRangeAction.action != ThreeButtonsWindowAction._ThirdButton)
                {
                    this.Action = frmAction.frmRangeAction.action;
                    CloseWithOK();
                }
        }

        public Values DialogValues()
        {
            return new Values(SelectedInterval, Action);
        }
    }
}
