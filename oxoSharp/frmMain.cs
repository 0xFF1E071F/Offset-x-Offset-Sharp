//#define debug
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Threading;
using oxoSharp.Core;

namespace oxoSharp
{
    /* TODO:
     *      >>> add automatique mode :
     *              - new form with stop pause/resume, local configs (divider, next range option ...etc)
     *              - a global hotkey to pause
     *              - automatically create files, scan, update range, redo until no file left
     *              - according to local configs next range will be 
     *                  ○ first
     *                  ○ last
     *                  ○ random
     *              - the work stops when no file is found, then the previous undetected range is the viral signature
     *              - if the viral signature length is greater than a threshold (configurable) split it to fixed+variable range and continue the work
     *              - save history of results
     *      >>> add half automatique mode :
     *              - the purpose of this mode is to isolate multiple signtures
     *              - the form stars directly with "max sig size" as the size of variable range
     *              - this mode can be started directy from result form (:/)
     *		>>> Select ranges from bytemap
     *		>>> scan button
     *		
     *  actual progress:
     *  
     *      (remains scan) continue writing the code of other buttons (I know, new forms are boring but it has to bone)
     *      (done) add a new form (again?? :/) that shows PE sections (cool! some PE stuff) with the possibility to select them as ranges
     *      (done) mulitranges? a hell of a work but the result is worth it
     *      (done) add the possibility to modify some constants and default behavior 
     *             (done) SizeDivider
     *             (done) whether detect PE or not
     *             (done) Clear session when new exe loaded
     *		
     *      (I'll think about it) in case of auto detection of PE file is disabled (see prvious line), add a button to manually detect
     *		(done) Copy results to clipboard
     *      (done) add manual save/load session in/from a file
     *      (done) Go becomes Stop (and it actually stops)
     *      (done) continue btnSections_keypressed
     *      (done) button result
     *      (not fully done but satisfying) Continue with fixed ranges (both in C# and in ASM ::evil::)
     *          (done) Add fixed ranges from frmSections and from frmResult
     *          (done, not tested yet) add a fixed range function in dll
     *          (done) update bytemap to show fixed ranges
     *          (postponed..) -> fixed ranges tab :
     *                  (done)show ranges in listview
     *                  (done)add
     *                  (done)remove 
     *                  (done)clear
     *                  (done)edit
     *                  (done)split
     *                  (done)merge
     *                  >>> (later)clean up (this should automatically merge ranges and remove useless ones)
     *          (done) show isPE and selected config (mode and value) under progress bar
     *          -> (working...) check fixed ranges collision with variable range
     *                  (will be done during clean up)-> Ask to manually split : if the variable range is inside a fixed range, the fixed
     *                                            is permanently split to 2 ranges, and shown in GUI and
     *                                            saved as two ranges
     *                  (done) Auto split : the fixed range is split just temporarily to not override the variable
     *                                 range, not changed in GUI and save file
     *          (done) make the program apply fixed ranges
     *          
     *      (done) modes help buttons : show a new form that explains range variation with byte map        
     *      (done) config button
     *      (done) Optimize bytemap2 : recalculate rectangles in onResize only
     *      
     */

    public partial class frmMain : Form
    {
        #region Fields
        private string _originalFormText = "oxoSharp " + GlobalDataAndMethods.currentVersion;
        private int _filesize; // the size of the dropped file

        private MyList<int[]> FixedRanges = new MyList<int[]>();

        private PEinfo _peinfo;


        private oxoCore _oxoCore;


        #endregion

        #region .ctor
        public frmMain()
        {
            InitializeComponent();
            this.Text = _originalFormText;
            FixedRanges.ModifiedListEventHandler += FixedRanges_Modified;
        }
        #endregion

        #region TextBoxes methods
        private void SetEofRangeToGui()
        {
            if (PEinfo.isPE)
                SetRangeToGui(PEinfo.AddressOfEOF, PEinfo.FileSize);
        }
        private void SetHeaderRangeToGui()
        {
            if (PEinfo.isPE)
                SetRangeToGui(0, PEinfo.SizeOfHeader);
        }

        private void SetDefaultRangeToGui(string filename)
        {
            if (PEinfo.isPE)
                SetPeSectionsRangeToGui();
            else
                SetFullSizeRangeToGui();
            UpdateByteMap();
        }
        private void SetPeSectionsRangeToGui()
        {
            if (PEinfo.isPE)
                SetRangeToGui(PEinfo.SizeOfHeader, PEinfo.AddressOfEOF);
        }
        private void SetRangeToGui(int[] StartEnd)
        {
            SetRangeToGui(StartEnd[0], StartEnd[1]);
        }

        private void SetFullSizeRangeToGui()
        {
            SetRangeToGui(0, _filesize);
        }

        private void SetRangeToGui(int Start, int End)
        {
            SetRangeToGui(Start, End, (End - Start) / GlobalDataAndMethods.Config.SizeDivider);
        }
        private void SetRangeToGui(int Start, int End, int Size)
        {
            RemoveTextChangedHandlers();
            txtStart.Text = Start.ToString("X");
            txtEnd.Text = End.ToString("X"); ;
            SetTxtSize(Size);
            SetTextChangedHandlers();
        }
        private void SetTxtSize(int len)
        {
            txtSize.Text = (len > 0) ? len.ToString("x") : "1";
        }
        private void RemoveTextChangedHandlers()
        {
            txtStart.DisableHandlers();
            txtEnd.DisableHandlers();
            txtSize.DisableHandlers();
            //txtStart.TextChanged -= hexTextBoxes_TextChanged;
            //txtEnd.TextChanged -= hexTextBoxes_TextChanged;
            //txtSize.TextChanged -= hexTextBoxes_TextChanged;
        }
        private void SetTextChangedHandlers()
        {
            txtStart.EnableHandlers();
            txtEnd.EnableHandlers();
            txtSize.EnableHandlers();
            //txtStart.TextChanged += hexTextBoxes_TextChanged;
            //txtEnd.TextChanged += hexTextBoxes_TextChanged;
            //txtSize.TextChanged += hexTextBoxes_TextChanged;
            UpdateByteMap();
        }
        private bool CheckStartAndEnd(Session session)
        {
            if (session.end > _filesize)
                session.end = _filesize;

            if (session.start >= session.end)
            {
                txtStart.Flash();
                return false;
            }

            if (session.size <= 0)
            {
                txtSize.Flash();
                return false;
            }
            return true;
        }
        private void FillTextBoxes(Session session)
        {
            RemoveTextChangedHandlers();
            LoadFile(session.fileLocation, false, false);
            SetRangeToGui(session.start, session.end, session.size);
            txtValue.Text = session.value.ToString("X");
            txtOutput.Text = session.output;
            SetTextChangedHandlers();
        }
        #endregion

        #region EventHandlers
        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalDataAndMethods.NagScreen();
            if (GlobalDataAndMethods.Config.ReloadLastSessionOnStartup)
                LoadPreviousSession();

        }
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ReadSession().isEmpty() || QuestionMessageBox("Load previous session?"))
                LoadPreviousSession();
        }
        void FixedRanges_Modified()
        {
            FixedRanges.Sort(new Comparison<int[]>((a, b) =>
            {
                return a[0] - b[0];
            }));
            ShowRangesInLV();
            byteMap1.FixedRanges = FixedRanges.ToArray();
            byteMap1.ReDraw();
        }


        private void btnResult_Click(object sender, EventArgs e)
        {
            OxoCore.Session.output = txtOutput.Text;
            using (frmResult result = new frmResult(OxoCore.ListUndetectedIntervals()))
            {
                RangeOptions(result);
            }
        }

        private void textBox1_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Move : DragDropEffects.None;
        }

        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
                LoadFile(files[0]);
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                LoadFile(openFileDialog1.FileName);
        }
        //private void hexTextBoxes_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 8 || e.KeyChar == 22 || e.KeyChar == 3) // backspace, paste, copy
        //        return;
        //    if (!isHexChar(e.KeyChar))
        //        e.Handled = true;
        //}
        private void hexTextBoxes_TextChanged(object sender, EventArgs e)
        {
            //bool changed = false;
            //TextBox textbox = (TextBox)sender;
            //string newText = "";
            //string oldText = textbox.Text;
            //foreach (char c in oldText)
            //{
            //    if (isHexChar(c))
            //        newText += c.ToString();
            //    else
            //        changed = true;
            //}
            //if (changed)
            //{
            //    textbox.TextChanged -= hexTextBoxes_TextChanged;
            //    textbox.Text = newText;
            //    textbox.TextChanged += hexTextBoxes_TextChanged;
            //}
            UpdateByteMap();
        }
        private void btnAutoSize_Click(object sender, EventArgs e)
        {
            int end, start;
            if (txtStart.ParseText(out start) /*ParseTxtStart(out start)*/ && txtEnd.ParseText(out end)/*ParseTxtEnd(out end)*/)
                SetTxtSize(GlobalDataAndMethods.AutoCalculateSize(start, end));
            else
                ErrorParsingMessage("Start or End");
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtSize.DisableHandlers();
            //txtSize.TextChanged -= hexTextBoxes_TextChanged;
            int hexval;
            if (txtSize.ParseText(out hexval)/* ParseTxtSize(out hexval)*/ && hexval < 0x10000000)
                txtSize.Text = (hexval * 0x10).ToString("X");
            //txtSize.TextChanged += hexTextBoxes_TextChanged;
            txtSize.EnableHandlers();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtSize.DisableHandlers();
            //txtSize.TextChanged -= hexTextBoxes_TextChanged;
            int hexval;
            if (txtSize.ParseText(out hexval) /*ParseTxtSize(out hexval)*/)
            {
                hexval /= 0x10;
                if (hexval == 0)
                    txtSize.Text = "1";
                else
                    txtSize.Text = hexval.ToString("X");
            }
            //txtSize.TextChanged += hexTextBoxes_TextChanged;
            txtSize.EnableHandlers();
        }
        private void btnOpenOutputFolder_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(txtOutput.Text))
                GlobalDataAndMethods.RunProcess(txtOutput.Text, "", true);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (GlobalDataAndMethods.Config.AutoSaveSessionOnExit)
                SaveSession();
            SaveConfig();
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            using (frmSections frmSections = new frmSections(PEinfo))
            {
                RangeOptions(frmSections);
            }
        }

        private void btnEof_Click(object sender, EventArgs e)
        {
            SetEofRangeToGui();
        }

        private void radioFixed_CheckedChanged(object sender, EventArgs e)
        {
            lblSizeOrStep.Text = radioFixed.Checked ? "Size" : "Step";

            if (radioFixed.Checked)
                lblMode.Text = "Fixed";
            else if (radioUnkFromStart.Checked)
                lblMode.Text = "Unk. from start";
            else
                lblMode.Text = "Unk. from end";
        }

        private void btnFullSize_Click(object sender, EventArgs e)
        {
            SetFullSizeRangeToGui();
        }

        private void btnHeader_Click(object sender, EventArgs e)
        {
            SetHeaderRangeToGui();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            if (IsGoButton())
                Go();
            else
                Stop();
        }
        private void btnScan_Click(object sender, EventArgs e)
        {
            GlobalDataAndMethods.Scan();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(FixedRangeDescription);
            ShowHelp(Help.Fixed);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowHelp(Help.UnkSizeFromStart);
            //MessageBox.Show(VariableRangeFromStartDescription);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowHelp(Help.UnkSizeFromEnd);
            //MessageBox.Show(VarialbeRangeFromEndDescrpiption);
        }

        private void itemAdd_Click(object sender, EventArgs e)
        {
            using (frmAddRange frmadd = new frmAddRange("Add range"))
            {
                if (frmadd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    FixedRanges.Add(frmadd.Range);
                }
            }
        }

        private void itemRemove_Click(object sender, EventArgs e)
        {
            if (!QuestionMessageBox("Delete selected item?")) return;
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                if (lvi.Tag is int[])
                    FixedRanges.Remove((int[])lvi.Tag);
                else
                    MessageBox.Show(this, string.Format("I couldn't delete item {0}-{1}", lvi.SubItems[0].Text, lvi.SubItems[1].Text));

            }
        }

        private void itemClear_Click(object sender, EventArgs e)
        {

            if (QuestionMessageBox("Remove all items?"))
                FixedRanges.Clear();
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                switch (listView1.SelectedItems.Count)
                {
                    case 0:
                        NoItemSelected();
                        break;
                    case 1:
                        OneItemSelected();
                        break;
                    default:
                        ManyItemsSelected();
                        break; ;
                }
                menuFixedRanges.Show(listView1, e.Location);
            }
        }

        private void itemEdit_Click(object sender, EventArgs e)
        {
            EditRange();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditRange();
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                EditRange();
        }

        private void itemSplit_Click(object sender, EventArgs e)
        {
            SplitRange();
        }

        private void itemMerge_Click(object sender, EventArgs e)
        {
            MergeRanges();
        }
        private void radioValue_CheckedChanged(object sender, EventArgs e)
        {
            if (radioValue.Checked)
                lblFill.Text = "Value";
            else if (radioNot.Checked)
                lblFill.Text = "Not";
            else
                lblFill.Text = "Xor";
        }

        private void lblMode_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void lblFill_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalDataAndMethods.ShowConfigForm();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmAbout about = new frmAbout())
            {
                about.ShowDialog();
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!ReadSession().isEmpty() && !QuestionMessageBox("You want to start a new session?"))
                return;
            LoadSession(new Session());
        }

        private void saveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveSessionAs();
        }
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadSessionAs();
        }

        #endregion

        #region Session and Config methods
        private void SaveSession()
        {
            SaverLoader.SaveSession(ReadSession());
        }

        private Session ReadSession()
        {
            Session session;
            ReadGui(out session, true);
            IncludeFixedRange(ref session);
            return session;
        }

        private void IncludeFixedRange(ref Session session)
        {
            session.UserDefinedFixedRanges = FixedRanges;
        }
        private void LoadPreviousSession()
        {
            Session session;
            SaverLoader.LoadSession(out session);
            LoadSession(session); // session is loaded even if it's empty to force the update of statusStrip;
        }

        private void LoadSession(Session session)
        {
            if (session == null) session = new Session();
            ExtractFixedRanges(session);
            FillTextBoxes(session);

            SetRangeMode((Mode)((int)session.mode & 0xFF00));
            SetFillMode((Mode)((int)session.mode & 0xFF));
            ForceUpdateStatusStrip();
            OxoCore.SetSession(session);

            UpdateByteMap();
        }

        private void ForceUpdateStatusStrip()
        {
            radioFixed_CheckedChanged(null, null);
            radioValue_CheckedChanged(null, null);
        }

        private void ExtractFixedRanges(Session session)
        {
            FixedRanges.Clear();
            if (session.UserDefinedFixedRanges != null && session.UserDefinedFixedRanges.Count != 0)
                FixedRanges.AddRange(session.UserDefinedFixedRanges);
        }

        private void SaveConfig()
        {
            SaverLoader.SaveConfig(GlobalDataAndMethods.Config);
        }
        #endregion

        #region RadioButtons methods
        private void SetFillMode(Mode mode)
        {
            switch (mode)
            {
                case Mode._value:
                    radioValue.Checked = true;
                    break;
                case Mode._not:
                    radioNot.Checked = true;
                    break;
                case Mode._random:
                    radioRandom.Checked = true;
                    break;
            }
        }

        private void SetRangeMode(Mode mode)
        {
            switch (mode)
            {
                case Mode._normal:
                    radioFixed.Checked = true;
                    break;
                case Mode._unknownFromEnd:
                    RadioUnkFromEnd.Checked = true;
                    break;
                case Mode._unknownFromStart:
                    radioUnkFromStart.Checked = true;
                    break;
            }
        }
        #endregion

        #region Uncategorized methods
        private void LoadFile(string filename, bool NewSession = true, bool clearRanges = true)
        {
            try
            {
                txtFileName.Text = filename;
                txtFileName.SelectionLength = 0;
                SetFormText(Path.GetFileName(filename));

                if (File.Exists(filename))
                {
                    using (FileStream fs = File.OpenRead(filename))
                    {
                        _filesize = (int)fs.Length;
                        ExtractPeInfo(filename);

                        if (GlobalDataAndMethods.Config.ReinitSessionOnFileLoad)
                        {
                            if (clearRanges)
                                FixedRanges.Clear();
                            if (NewSession) // to avoid overwriting previous session ranges
                                SetDefaultRangeToGui(filename);
                        }

                        SetStatusStripPEText(this.PEinfo.isPE.ToString());
                        return;
                    }
                }
                else throw new Exception("The file doesn't exist");
            }
            catch (Exception ex)
            {
                if (NewSession) MessageBox.Show(this, ex.Message);
                EmptyFileInfo();
            }
        }

        private void EmptyFileInfo()
        {
            SetFormText();
            SetStatusStripPEText();
            btnHeader.Enabled = btnSections.Enabled = false;
            btnEof.Enabled = PEinfo.hasEOF;
            PEinfo = new PEinfo();
            _filesize = 0;
        }

        private void SetStatusStripPEText(string text = "N/A")
        {
            lblPE.Text = text;
        }
        private void Stop()
        {
            StopBecomesGo();
            autoProcessToolStripMenuItem.Enabled = true;
            OxoCore.StopWork();
        }

        private void Go()
        {
            if (SetOxoCoreSessionFromGUI())
                DoWork();
        }

        private bool SetOxoCoreSessionFromGUI()
        {
            Session session;
            if (ReadGui(out session) && CheckStartAndEnd(session))
            {
                progressBar1.Value = 0;
                // this is a temporary session, so fixed ranges are not changed in GUI
                session.SetFixedRangesWithoutCollisionWithVariableRange(FixedRanges);
                OxoCore.SetSession(session);
                return true;
            }
            return false;
        }

        private void DoWork()
        {
            try
            {
                autoProcessToolStripMenuItem.Enabled = false;
                OxoCore.DoWork();
                if (OxoCore.Error != "")
                    MessageBox.Show(this, OxoCore.Error);
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); Stop(); }

        }

        private bool IsGoButton()
        {
            if (btnGo.Text == "&Go")
            {
                btnGo.Text = "&Stop";
                return true;
            }
            return false;
        }
        private bool ExtractPeInfo(string filename, bool ManualDetection = false)
        {
            this.PEinfo = (GlobalDataAndMethods.Config.AutoDetectPE || ManualDetection) ? PEinfo.ExtractInfo(filename) : new PEinfo();
            btnHeader.Enabled = btnSections.Enabled = PEinfo.isPE;
            btnEof.Enabled = PEinfo.hasEOF;
            return PEinfo.isPE;
        }

        private void SetFormText(string target = "")
        {
            string formText = _originalFormText;
            if (target != "")
                formText += string.Format(" - [{0}]", target);
            this.Text = formText;
        }
        private void ShowRangesInLV()
        {
            listView1.Items.Clear();
            listView1.Items.AddRange((from Range in FixedRanges
                                      where Range.Length >= 2
                                      select new ListViewItem(new string[]
                                      { 
                                        Range[0].ToString("X"),
                                        Range[1].ToString("X"),
                                        (Range[1] - Range[0]).ToString("X") 
                                      }) { Tag = Range }).ToArray());
        }
        private void UpdateByteMap()
        {
            int start;
            int end;
            int size;
            if (txtStart.ParseText(out start) /*ParseTxtStart(out start)*/ && txtEnd.ParseText(out end)/*ParseTxtEnd(out end)*/ && txtSize.ParseText(out size)/*ParseTxtSize(out size)*/)
            {
                if (end > _filesize)
                    end = _filesize;
                if (!(start < end && start >= 0))
                {
                    start = 0;
                    end = 0;
                }
                byteMap1.startOffset = start;
                byteMap1.endOffset = end;
                byteMap1.SizeOfTheFile = _filesize;
                byteMap1.SmallRangeWidth = size;

                if (PEinfo.isPE)
                {
                    byteMap1.EOFsize = PEinfo.SizeOfEOF;
                    byteMap1.PeHeaderSize = PEinfo.SizeOfHeader;
                }
                else
                {
                    byteMap1.EOFsize = 0;
                    byteMap1.PeHeaderSize = 0;
                }

                byteMap1.ReDraw();
            }
        }
        private bool ReadGui(out Session session, bool silent = false)
        {
            // Silent mode is used when saving session, in this case the program doesn't
            // complain about the inexistence of files and the unreadabilty of textboxes,
            // it just reads the maximum of informations, saves them and close
            session = new Session();

            // read input file
            session.fileLocation = txtFileName.Text;

            // Of output directory
            session.output = txtOutput.Text;

            // complain about the existence of input and output 
            if (!silent)
            {
                if (session.fileLocation == "")
                { txtFileName.Flash(); /*MessageBox.Show(this, "Please select a file");*/ return false; }

                if (session.output == "")
                { txtOutput.Flash();/*MessageBox.Show(this, "Please select an output folder");*/ return false; }

                if (!Directory.Exists(session.output))
                    if (QuestionMessageBox("Output folder doesn't exist create it?"))
                        Directory.CreateDirectory(session.output);
                    else return false;
            }
            // Of mode
            session.mode = (radioNot.Checked) ? Mode._not : ((radioRandom.Checked) ? Mode._random : Mode._value);
            session.mode |= (radioUnkFromStart.Checked) ? Mode._unknownFromStart : ((RadioUnkFromEnd.Checked) ? Mode._unknownFromEnd : Mode._normal);

            // Of value
            if (!hexParser(txtValue, "value", out session.value, silent))
                if (!silent) return false;

            // Of start, end and step
            if (!hexParser(txtStart, "start address", out session.start, silent))
                if (!silent) return false;

            if (!hexParser(txtEnd, "end address", out session.end, silent))
                if (!silent) return false;

            if (!hexParser(txtSize, "size/step", out session.size, silent))
                if (!silent) return false;

            return true;
        }

        private void ErrorParsingMessage(string p)
        {
            MessageBox.Show(this, "I couldn't parse " + p);
        }
        private void progress(object obj, ProgressChangedEventArgs args)
        {
            progressBar1.Value = args.ProgressPercentage;
        }
        private void WorkDone(object obj, RunWorkerCompletedEventArgs args)
        {
            StopBecomesGo();
            autoProcessToolStripMenuItem.Enabled = true;
            InformationMessageBox("Work done!");
        }

        private void StopBecomesGo()
        {
            if (btnGo.Text == "&Stop")
                btnGo.Text = "&Go";
        }

        private void InformationMessageBox(string message)
        {
            MessageBox.Show(this, message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void AddToFixedRanges(int[] StartEnd)
        {
            if (StartEnd.Length > 1)
                AddToFixedRanges(StartEnd[0], StartEnd[1]);
        }
        private void AddToFixedRanges(int Start, int End)
        {
            FixedRanges.Add(new int[] { Start, End });
        }
        private void ManyItemsSelected()
        {
            itemMerge.Enabled = SelectedRangesAreAdjacent();
            itemRemove.Enabled = true;
            itemEdit.Enabled = itemSplit.Enabled = false;
        }

        private bool SelectedRangesAreAdjacent()
        {
            int index = listView1.SelectedItems[0].Index;
            for (int i = 1; i < listView1.SelectedItems.Count; i++)
                if (listView1.SelectedItems[i].Index != ++index)
                    return false;
            return true;
        }

        private void OneItemSelected()
        {
            itemMerge.Enabled = false;
            itemRemove.Enabled = itemEdit.Enabled = itemSplit.Enabled = true;
        }

        private void NoItemSelected()
        {
            itemMerge.Enabled = itemRemove.Enabled = itemEdit.Enabled = itemSplit.Enabled = false;
        }

        private void EditRange()
        {
            if (listView1.SelectedItems.Count == 1)
            {
                int[] Range = ReadSelectedRange();
                using (frmAddRange EditRange = new frmAddRange("Edit range", Range))
                {
                    if (EditRange.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        this.FixedRanges.Remove(Range);
                        this.FixedRanges.Add(EditRange.Range);
                    }
                }
            }
        }

        private void SplitRange()
        {
            int[] Range = ReadSelectedRange();
            int middle = (Range[0] + Range[1]) / 2;
            List<int[]> Ranges = new List<int[]>();

            Ranges.Add(new int[] { Range[0], middle });
            Ranges.Add(new int[] { middle, Range[1] });
            FixedRanges.AddRange(Ranges);
            FixedRanges.Remove(Range);
        }

        private int[] ReadSelectedRange()
        {
            return (int[])listView1.SelectedItems[0].Tag;
        }
        private List<int[]> ReadSelectedRanges()
        {
            List<int[]> Ranges = new List<int[]>();
            foreach (ListViewItem item in listView1.SelectedItems)
                Ranges.Add((int[])item.Tag);
            return Ranges;
        }


        private void MergeRanges()
        {
            List<int[]> Ranges = ReadSelectedRanges();
            foreach (int[] Range in Ranges)
                FixedRanges.Remove(Range);
            FixedRanges.Add(new int[] { Ranges.First()[0], Ranges.Last()[1] });
        }



        private void SaveSessionAs()
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if (SaverLoader.SaveSession(ReadSession(), saveFileDialog1.FileName))
                        InformationMessageBox("Saved!");
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
        }

        private void RangeOptions(IIntervalForm IntervalForm)
        {
            if (IntervalForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Values Values = IntervalForm.DialogValues();
                if ((RangeAction)Values.Action == RangeAction._defaultrange)
                    SetRangeToGui(Values.SelectedInterval);
                else if ((RangeAction)Values.Action == RangeAction._fixedrange)
                    AddToFixedRanges(Values.SelectedInterval);
            }
        }

        private void LoadSessionAs()
        {
            try
            {
                if (!ReadSession().isEmpty() && QuestionMessageBox("Save current session before?"))
                    SaveSessionAs();
                if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Session session;
                    if (SaverLoader.LoadSession(out session, openFileDialog2.FileName))
                    {
                        LoadSession(session);
                        InformationMessageBox("Loaded!");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(this, ex.Message); }
        }
        private bool QuestionMessageBox(string message)
        {
            return MessageBox.Show(this, message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes;
        }
        private void ShowHelp(Help help)
        {
            using (frmHelp frmhelp = new frmHelp(help))
            {
                frmhelp.ShowDialog();
            }
        }
        #endregion

        #region HexParsing
        private bool hexParser(UserControls.HexTextBox hextextbox, string nameOfString, out int parsedHex, bool silent = true)
        {
            if (!hextextbox.ParseText(out parsedHex))
            {
                if (!silent) ErrorParsingMessage(nameOfString);
                return false;
            }
            return true;
        }
        //private bool isHexChar(char c)
        //{
        //    return ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F'));
        //}
        //private bool ParseTxtSize(out int hexval)
        //{
        //    return ParseHex(txtSize.Text, out hexval);
        //}
        //private bool ParseTxtStart(out int hexval)
        //{
        //    return ParseHex(txtStart.Text, out hexval);
        //}
        //private bool ParseTxtEnd(out int hexval)
        //{
        //    return ParseHex(txtEnd.Text, out hexval);
        //}
        //private bool ParseTxtValue(out int hexval)
        //{
        //    return ParseHex(txtValue.Text, out hexval);
        //}
        //private bool ParseHex(string hexString, out int hexval)
        //{
        //    return int.TryParse(hexString, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out hexval);
        //}
        #endregion

        #region Properties
        public oxoCore OxoCore
        {
            get
            {
                if (_oxoCore == null)
                    _oxoCore = new oxoCore(new ProgressChangedEventHandler(progress), new RunWorkerCompletedEventHandler(WorkDone));
                return _oxoCore;
            }
        }
        private PEinfo PEinfo
        {
            get
            {
                if (_peinfo == null)
                    _peinfo = new PEinfo();
                return _peinfo;
            }
            set
            {
                _peinfo = value;
            }
        }
        #endregion

        private void autoProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //AutoProcess();
        }

        private void AutoProcess()
        {
            if (SetOxoCoreSessionFromGUI())
                StartAutoProcessForm();
        }

        private void StartAutoProcessForm()
        {
            if (OxoCore.IsBusy() && MessageBox.Show(this, "Busy", "Program working in the background, force stop?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                OxoCore.StopWork();
            
            if (!OxoCore.IsBusy())
                using (frmAuto frmAuto = new frmAuto(ReadSession()))
                {
                    frmAuto.ShowDialog();
                }
        }
    }
}