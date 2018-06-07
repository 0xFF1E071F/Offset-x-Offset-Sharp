using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oxoSharp
{
    public partial class frmResult : Form, IIntervalForm
    {
        int[][] UndetectedIntervals;

        public int[] SelectedInterval;
        public ThreeButtonsWindowAction Action;

        public Values DialogValues()
        {
            return new Values(SelectedInterval, Action);
        }

        private bool shift;
        public frmResult(int[][] UndetectedIntervals)
        {
            InitializeComponent();
            this.UndetectedIntervals = UndetectedIntervals;
            this.KeyPreview = true;
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void frmResult_Load(object sender, EventArgs e)
        {
            if (UndetectedIntervals == null || UndetectedIntervals.Length == 0) return;
            int i = 0;
            Color[] colors = new Color[] { Color.LightBlue, Color.LightSkyBlue };
            listView1.Items.AddRange(
                (from undetected in UndetectedIntervals
                 where undetected != null
                 select new ListViewItem(
                     new string[]{
                            undetected[0].ToString("X"),
                            undetected[1].ToString("X"),
                            (undetected[1] - undetected[0]).ToString("X")
                            })
                 { BackColor = colors[i++ % 2], Tag = new int[] { undetected[0], undetected[1], undetected[1] - undetected[0] } }).ToArray());
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listView1.Sorting = (listView1.Sorting == SortOrder.Descending) ? SortOrder.Ascending : SortOrder.Descending;
            listView1.ListViewItemSorter = new Comparer(e.Column, listView1.Sorting);
            listView1.Sort();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            SelectAction();
        }

        private void SelectAction()
        {
            if (listView1.SelectedItems.Count == 0) return;
            if (frmAction.frmRangeAction.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                if ((RangeAction)frmAction.frmRangeAction.action != RangeAction._cancel)
                {
                    this.Action = frmAction.frmRangeAction.action;
                    this.SelectedInterval = (int[])listView1.SelectedItems[0].Tag;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
        }

        private void frmResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int Copy = 3;
            if (e.KeyChar == 27)
                this.Close();
            else if (e.KeyChar == Copy && listView1.SelectedItems.Count > 0)
                if (shift)
                    AdvancedCopy((int[])listView1.SelectedItems[0].Tag);
                else
                    CopyResults((int[])listView1.SelectedItems[0].Tag);
            shift = false;
        }

        private void AdvancedCopy(int[] range)
        {
            if (frmAction.frmAdvancedCopy.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                Clipboard.SetText(FormatOutput(range[(int)frmAction.frmAdvancedCopy.action]));
        }

        private void CopyResults(int[] range)
        {
            Clipboard.SetText(FormatOutput(range));
        }
        private void CopyResults()
        {
            Clipboard.SetText(ConvertUndetectedRangesToText());
        }

        private string ConvertUndetectedRangesToText()
        {
            string result = "";
            foreach (int[] r in UndetectedIntervals)
                result += FormatOutput(r);
            return result;
        }

        private static string FormatOutput(int[] r)
        {
            return GlobalDataAndMethods.OutputFormat(r[0], r[1]) + Environment.NewLine;
        }
        private string FormatOutput(int v)
        {
            return GlobalDataAndMethods.OutputFormat(v);
        }
        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                SelectAction();
        }

        private void btnCopyResults_Click(object sender, EventArgs e)
        {
            CopyResults();
        }

        private void frmResult_KeyDown(object sender, KeyEventArgs e)
        {
            this.shift = e.Shift;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = ConvertUndetectedRangesToText();
            saveFileDialog1.FileName = string.Format(
                "Result from {0:X8} to {1:X8} ({2} entry).txt",
                UndetectedIntervals.First()[0],
                UndetectedIntervals.Last()[1],
                UndetectedIntervals.Length
                );
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                File.WriteAllText(saveFileDialog1.FileName, data);
        }
    }
    public class Comparer : IComparer
    {
        int Column;
        SortOrder order;
        internal Comparer(int Column, SortOrder order)
        {
            this.Column = Column;
            this.order = order;
        }
        public int Compare(object A, object B)
        {
            try
            {
                return OrderFactor * (ExtractIntFromTag(A) - ExtractIntFromTag(B));
            }
            catch { return 0; }
        }

        private int ExtractIntFromTag(object A)
        {
            return ((int[])((ListViewItem)A).Tag)[Column];
        }

        public int OrderFactor { get { return (order == SortOrder.Ascending) ? 1 : -1; } }
    }
}
