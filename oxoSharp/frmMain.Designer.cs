namespace oxoSharp
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new oxoSharp.UserControls.FlashingTextBox();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOutput = new oxoSharp.UserControls.FlashingTextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblSizeOrStep = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.radioValue = new System.Windows.Forms.RadioButton();
            this.radioNot = new System.Windows.Forms.RadioButton();
            this.radioRandom = new System.Windows.Forms.RadioButton();
            this.radioFixed = new System.Windows.Forms.RadioButton();
            this.radioUnkFromStart = new System.Windows.Forms.RadioButton();
            this.RadioUnkFromEnd = new System.Windows.Forms.RadioButton();
            this.btnHeader = new System.Windows.Forms.Button();
            this.btnSections = new System.Windows.Forms.Button();
            this.btnEof = new System.Windows.Forms.Button();
            this.btnFullSiz = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btnAutoSize = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStart = new oxoSharp.UserControls.HexTextBox();
            this.txtEnd = new oxoSharp.UserControls.HexTextBox();
            this.txtSize = new oxoSharp.UserControls.HexTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblFillWith = new System.Windows.Forms.Label();
            this.txtValue = new oxoSharp.UserControls.HexTextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFixedRanges = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.itemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.itemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.itemCleanUp = new System.Windows.Forms.ToolStripMenuItem();
            this.byteMap1 = new oxoSharp.UserControls.ByteMap2();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPE = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFill = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.menuFixedRanges.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "File";
            // 
            // txtFileName
            // 
            this.txtFileName.AllowDrop = true;
            this.txtFileName.FlashColor = System.Drawing.Color.Red;
            this.txtFileName.Location = new System.Drawing.Point(60, 42);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(323, 22);
            this.txtFileName.TabIndex = 1;
            this.txtFileName.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop);
            this.txtFileName.DragOver += new System.Windows.Forms.DragEventHandler(this.textBox1_DragOver);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(392, 39);
            this.btnLoadFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(47, 28);
            this.btnLoadFile.TabIndex = 2;
            this.btnLoadFile.Text = "...";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Start";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "End";
            // 
            // txtOutput
            // 
            this.txtOutput.FlashColor = System.Drawing.Color.Red;
            this.txtOutput.Location = new System.Drawing.Point(60, 76);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(280, 22);
            this.txtOutput.TabIndex = 3;
            this.txtOutput.Text = "c:\\output";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(9, 382);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 33);
            this.btnGo.TabIndex = 22;
            this.btnGo.Text = "&Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 80);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Output";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Exes|*.exe|Dlls|*.dll|All files|*.*";
            this.openFileDialog1.Title = "Select file";
            // 
            // lblSizeOrStep
            // 
            this.lblSizeOrStep.AutoSize = true;
            this.lblSizeOrStep.Location = new System.Drawing.Point(7, 78);
            this.lblSizeOrStep.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSizeOrStep.Name = "lblSizeOrStep";
            this.lblSizeOrStep.Size = new System.Drawing.Size(35, 17);
            this.lblSizeOrStep.TabIndex = 5;
            this.lblSizeOrStep.Text = "Size";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 422);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(425, 28);
            this.progressBar1.TabIndex = 11;
            // 
            // radioValue
            // 
            this.radioValue.AutoSize = true;
            this.radioValue.Checked = true;
            this.radioValue.Location = new System.Drawing.Point(35, 42);
            this.radioValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioValue.Name = "radioValue";
            this.radioValue.Size = new System.Drawing.Size(101, 21);
            this.radioValue.TabIndex = 15;
            this.radioValue.TabStop = true;
            this.radioValue.Text = "Value (hex)";
            this.radioValue.UseVisualStyleBackColor = true;
            this.radioValue.CheckedChanged += new System.EventHandler(this.radioValue_CheckedChanged);
            // 
            // radioNot
            // 
            this.radioNot.AutoSize = true;
            this.radioNot.Location = new System.Drawing.Point(35, 69);
            this.radioNot.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioNot.Name = "radioNot";
            this.radioNot.Size = new System.Drawing.Size(51, 21);
            this.radioNot.TabIndex = 16;
            this.radioNot.TabStop = true;
            this.radioNot.Text = "Not";
            this.radioNot.UseVisualStyleBackColor = true;
            this.radioNot.CheckedChanged += new System.EventHandler(this.radioValue_CheckedChanged);
            // 
            // radioRandom
            // 
            this.radioRandom.AutoSize = true;
            this.radioRandom.Location = new System.Drawing.Point(35, 97);
            this.radioRandom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioRandom.Name = "radioRandom";
            this.radioRandom.Size = new System.Drawing.Size(128, 21);
            this.radioRandom.TabIndex = 17;
            this.radioRandom.TabStop = true;
            this.radioRandom.Text = "xor with random";
            this.radioRandom.UseVisualStyleBackColor = true;
            this.radioRandom.CheckedChanged += new System.EventHandler(this.radioValue_CheckedChanged);
            // 
            // radioFixed
            // 
            this.radioFixed.AutoSize = true;
            this.radioFixed.Checked = true;
            this.radioFixed.Location = new System.Drawing.Point(35, 42);
            this.radioFixed.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioFixed.Name = "radioFixed";
            this.radioFixed.Size = new System.Drawing.Size(91, 21);
            this.radioFixed.TabIndex = 16;
            this.radioFixed.TabStop = true;
            this.radioFixed.Text = "Fixed size";
            this.radioFixed.UseVisualStyleBackColor = true;
            this.radioFixed.CheckedChanged += new System.EventHandler(this.radioFixed_CheckedChanged);
            // 
            // radioUnkFromStart
            // 
            this.radioUnkFromStart.AutoSize = true;
            this.radioUnkFromStart.Location = new System.Drawing.Point(35, 69);
            this.radioUnkFromStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioUnkFromStart.Name = "radioUnkFromStart";
            this.radioUnkFromStart.Size = new System.Drawing.Size(197, 21);
            this.radioUnkFromStart.TabIndex = 20;
            this.radioUnkFromStart.Text = "Unknown size -> from start";
            this.radioUnkFromStart.UseVisualStyleBackColor = true;
            this.radioUnkFromStart.CheckedChanged += new System.EventHandler(this.radioFixed_CheckedChanged);
            // 
            // RadioUnkFromEnd
            // 
            this.RadioUnkFromEnd.AutoSize = true;
            this.RadioUnkFromEnd.Location = new System.Drawing.Point(35, 97);
            this.RadioUnkFromEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RadioUnkFromEnd.Name = "RadioUnkFromEnd";
            this.RadioUnkFromEnd.Size = new System.Drawing.Size(193, 21);
            this.RadioUnkFromEnd.TabIndex = 21;
            this.RadioUnkFromEnd.Text = "Unknown size -> from end";
            this.RadioUnkFromEnd.UseVisualStyleBackColor = true;
            this.RadioUnkFromEnd.CheckedChanged += new System.EventHandler(this.radioFixed_CheckedChanged);
            // 
            // btnHeader
            // 
            this.btnHeader.Enabled = false;
            this.btnHeader.Location = new System.Drawing.Point(37, 18);
            this.btnHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHeader.Name = "btnHeader";
            this.btnHeader.Size = new System.Drawing.Size(147, 28);
            this.btnHeader.TabIndex = 11;
            this.btnHeader.Text = "Header only";
            this.btnHeader.UseVisualStyleBackColor = true;
            this.btnHeader.Click += new System.EventHandler(this.btnHeader_Click);
            // 
            // btnSections
            // 
            this.btnSections.Enabled = false;
            this.btnSections.Location = new System.Drawing.Point(37, 46);
            this.btnSections.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSections.Name = "btnSections";
            this.btnSections.Size = new System.Drawing.Size(147, 28);
            this.btnSections.TabIndex = 12;
            this.btnSections.Text = "Sections";
            this.btnSections.UseVisualStyleBackColor = true;
            this.btnSections.Click += new System.EventHandler(this.btnSections_Click);
            // 
            // btnEof
            // 
            this.btnEof.Enabled = false;
            this.btnEof.Location = new System.Drawing.Point(37, 73);
            this.btnEof.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEof.Name = "btnEof";
            this.btnEof.Size = new System.Drawing.Size(147, 28);
            this.btnEof.TabIndex = 13;
            this.btnEof.Text = "EOF";
            this.btnEof.UseVisualStyleBackColor = true;
            this.btnEof.Click += new System.EventHandler(this.btnEof_Click);
            // 
            // btnFullSiz
            // 
            this.btnFullSiz.Location = new System.Drawing.Point(37, 100);
            this.btnFullSiz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFullSiz.Name = "btnFullSiz";
            this.btnFullSiz.Size = new System.Drawing.Size(147, 28);
            this.btnFullSiz.TabIndex = 14;
            this.btnFullSiz.Text = "Full";
            this.btnFullSiz.UseVisualStyleBackColor = true;
            this.btnFullSiz.Click += new System.EventHandler(this.btnFullSize_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Location = new System.Drawing.Point(107, 106);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(29, 25);
            this.btnPlus.TabIndex = 9;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Location = new System.Drawing.Point(137, 106);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(29, 25);
            this.btnMinus.TabIndex = 10;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(93, 382);
            this.btnScan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(79, 33);
            this.btnScan.TabIndex = 23;
            this.btnScan.Text = "S&can";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(357, 382);
            this.btnResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(79, 33);
            this.btnResult.TabIndex = 24;
            this.btnResult.Text = "&Result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(179, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(259, 17);
            this.label5.TabIndex = 27;
            this.label5.Text = "The content of this folder will be deleted";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(351, 74);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 27);
            this.button3.TabIndex = 4;
            this.button3.Text = "&Open";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnOpenOutputFolder_Click);
            // 
            // btnAutoSize
            // 
            this.btnAutoSize.Location = new System.Drawing.Point(48, 106);
            this.btnAutoSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAutoSize.Name = "btnAutoSize";
            this.btnAutoSize.Size = new System.Drawing.Size(57, 25);
            this.btnAutoSize.TabIndex = 8;
            this.btnAutoSize.Text = "Auto";
            this.btnAutoSize.UseVisualStyleBackColor = true;
            this.btnAutoSize.Click += new System.EventHandler(this.btnAutoSize_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(9, 124);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(429, 175);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblSizeOrStep);
            this.tabPage1.Controls.Add(this.txtStart);
            this.tabPage1.Controls.Add(this.btnMinus);
            this.tabPage1.Controls.Add(this.txtEnd);
            this.tabPage1.Controls.Add(this.btnAutoSize);
            this.tabPage1.Controls.Add(this.txtSize);
            this.tabPage1.Controls.Add(this.btnPlus);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(421, 146);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Variable range";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnHeader);
            this.groupBox1.Controls.Add(this.btnSections);
            this.groupBox1.Controls.Add(this.btnEof);
            this.groupBox1.Controls.Add(this.btnFullSiz);
            this.groupBox1.Location = new System.Drawing.Point(185, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(219, 135);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Predefined ranges";
            // 
            // txtStart
            // 
            this.txtStart.FlashColor = System.Drawing.Color.Red;
            this.txtStart.Location = new System.Drawing.Point(49, 11);
            this.txtStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStart.MaxLength = 8;
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(116, 22);
            this.txtStart.TabIndex = 5;
            this.txtStart.TextChanged += new System.EventHandler(this.hexTextBoxes_TextChanged);
            // 
            // txtEnd
            // 
            this.txtEnd.FlashColor = System.Drawing.Color.Red;
            this.txtEnd.Location = new System.Drawing.Point(49, 43);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEnd.MaxLength = 8;
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(116, 22);
            this.txtEnd.TabIndex = 6;
            this.txtEnd.TextChanged += new System.EventHandler(this.hexTextBoxes_TextChanged);
            // 
            // txtSize
            // 
            this.txtSize.FlashColor = System.Drawing.Color.Red;
            this.txtSize.Location = new System.Drawing.Point(49, 74);
            this.txtSize.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSize.MaxLength = 8;
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(116, 22);
            this.txtSize.TabIndex = 7;
            this.txtSize.TextChanged += new System.EventHandler(this.hexTextBoxes_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(421, 146);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Fixed ranges";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(5, 10);
            this.listView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(404, 118);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listView1_KeyPress);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            this.listView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Start";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "End";
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 80;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblFillWith);
            this.tabPage3.Controls.Add(this.radioValue);
            this.tabPage3.Controls.Add(this.radioRandom);
            this.tabPage3.Controls.Add(this.radioNot);
            this.tabPage3.Controls.Add(this.txtValue);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(421, 146);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Bytes operations";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblFillWith
            // 
            this.lblFillWith.AutoSize = true;
            this.lblFillWith.Location = new System.Drawing.Point(9, 14);
            this.lblFillWith.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFillWith.Name = "lblFillWith";
            this.lblFillWith.Size = new System.Drawing.Size(185, 17);
            this.lblFillWith.TabIndex = 19;
            this.lblFillWith.Text = "Select how to replace bytes:";
            // 
            // txtValue
            // 
            this.txtValue.FlashColor = System.Drawing.Color.Red;
            this.txtValue.Location = new System.Drawing.Point(143, 41);
            this.txtValue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValue.MaxLength = 2;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(39, 22);
            this.txtValue.TabIndex = 18;
            this.txtValue.Text = "FF";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.radioFixed);
            this.tabPage4.Controls.Add(this.RadioUnkFromEnd);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.radioUnkFromStart);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(421, 146);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Mode";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(243, 95);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(27, 25);
            this.button4.TabIndex = 24;
            this.button4.Text = "?";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(243, 66);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(27, 25);
            this.button2.TabIndex = 23;
            this.button2.Text = "?";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 39);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 25);
            this.button1.TabIndex = 22;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 14);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Select variable interval behavior :";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.undoToolStripMenuItem.Text = "&Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.redoToolStripMenuItem.Text = "&Redo";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
            this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.cutToolStripMenuItem.Text = "Cu&t";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
            this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.copyToolStripMenuItem.Text = "&Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
            this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.pasteToolStripMenuItem.Text = "&Paste";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.selectAllToolStripMenuItem.Text = "Select &All";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // menuFixedRanges
            // 
            this.menuFixedRanges.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemAdd,
            this.itemRemove,
            this.itemClear,
            this.toolStripSeparator6,
            this.itemEdit,
            this.itemSplit,
            this.itemMerge,
            this.itemCleanUp});
            this.menuFixedRanges.Name = "menuFixedRanges";
            this.menuFixedRanges.Size = new System.Drawing.Size(290, 178);
            // 
            // itemAdd
            // 
            this.itemAdd.Name = "itemAdd";
            this.itemAdd.Size = new System.Drawing.Size(289, 24);
            this.itemAdd.Text = "Add";
            this.itemAdd.Click += new System.EventHandler(this.itemAdd_Click);
            // 
            // itemRemove
            // 
            this.itemRemove.Name = "itemRemove";
            this.itemRemove.Size = new System.Drawing.Size(289, 24);
            this.itemRemove.Text = "Remove";
            this.itemRemove.Click += new System.EventHandler(this.itemRemove_Click);
            // 
            // itemClear
            // 
            this.itemClear.Name = "itemClear";
            this.itemClear.Size = new System.Drawing.Size(289, 24);
            this.itemClear.Text = "Clear";
            this.itemClear.Click += new System.EventHandler(this.itemClear_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(286, 6);
            // 
            // itemEdit
            // 
            this.itemEdit.Name = "itemEdit";
            this.itemEdit.Size = new System.Drawing.Size(289, 24);
            this.itemEdit.Text = "Edit";
            this.itemEdit.Click += new System.EventHandler(this.itemEdit_Click);
            // 
            // itemSplit
            // 
            this.itemSplit.Name = "itemSplit";
            this.itemSplit.Size = new System.Drawing.Size(289, 24);
            this.itemSplit.Text = "Split";
            this.itemSplit.Click += new System.EventHandler(this.itemSplit_Click);
            // 
            // itemMerge
            // 
            this.itemMerge.Name = "itemMerge";
            this.itemMerge.Size = new System.Drawing.Size(289, 24);
            this.itemMerge.Text = "Merge";
            this.itemMerge.Click += new System.EventHandler(this.itemMerge_Click);
            // 
            // itemCleanUp
            // 
            this.itemCleanUp.Name = "itemCleanUp";
            this.itemCleanUp.Size = new System.Drawing.Size(289, 24);
            this.itemCleanUp.Text = "Clean up (not implemented yet)";
            // 
            // byteMap1
            // 
            this.byteMap1.endOffset = 0;
            this.byteMap1.Location = new System.Drawing.Point(12, 304);
            this.byteMap1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.byteMap1.Name = "byteMap1";
            this.byteMap1.Size = new System.Drawing.Size(421, 71);
            this.byteMap1.SizeOfTheFile = 0;
            this.byteMap1.SmallRangeWidth = 0;
            this.byteMap1.startOffset = 0;
            this.byteMap1.TabIndex = 28;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lblPE,
            this.toolStripStatusLabel1,
            this.lblFill,
            this.toolStripStatusLabel3,
            this.lblMode});
            this.statusStrip1.Location = new System.Drawing.Point(0, 461);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(452, 29);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(36, 24);
            this.toolStripStatusLabel2.Text = "PE :";
            // 
            // lblPE
            // 
            this.lblPE.AutoSize = false;
            this.lblPE.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblPE.Name = "lblPE";
            this.lblPE.Size = new System.Drawing.Size(50, 24);
            this.lblPE.Text = "N/A";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(43, 24);
            this.toolStripStatusLabel1.Text = "Fill : ";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.lblFill_Click);
            // 
            // lblFill
            // 
            this.lblFill.AutoSize = false;
            this.lblFill.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblFill.Name = "lblFill";
            this.lblFill.Size = new System.Drawing.Size(50, 24);
            this.lblFill.Text = "N/A";
            this.lblFill.Click += new System.EventHandler(this.lblFill_Click);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(59, 24);
            this.toolStripStatusLabel3.Text = "Mode :";
            this.toolStripStatusLabel3.Click += new System.EventHandler(this.lblMode_Click);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = false;
            this.lblMode.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)(((System.Windows.Forms.ToolStripStatusLabelBorderSides.Top | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(90, 24);
            this.lblMode.Text = "N/A";
            this.lblMode.Click += new System.EventHandler(this.lblMode_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(452, 28);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sessionToolStripMenuItem
            // 
            this.sessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem1,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem2,
            this.loadToolStripMenuItem1,
            this.toolStripSeparator7,
            this.reloadToolStripMenuItem});
            this.sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            this.sessionToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.sessionToolStripMenuItem.Text = "&Session";
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(222, 24);
            this.saveToolStripMenuItem1.Text = "New";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(219, 6);
            // 
            // saveToolStripMenuItem2
            // 
            this.saveToolStripMenuItem2.Name = "saveToolStripMenuItem2";
            this.saveToolStripMenuItem2.Size = new System.Drawing.Size(222, 24);
            this.saveToolStripMenuItem2.Text = "Save";
            this.saveToolStripMenuItem2.Click += new System.EventHandler(this.saveToolStripMenuItem2_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(222, 24);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(219, 6);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(222, 24);
            this.reloadToolStripMenuItem.Text = "Load previous session";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionToolStripMenuItem,
            this.autoProcessToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(317, 24);
            this.optionToolStripMenuItem.Text = "Options";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // autoProcessToolStripMenuItem
            // 
            this.autoProcessToolStripMenuItem.Name = "autoProcessToolStripMenuItem";
            this.autoProcessToolStripMenuItem.Size = new System.Drawing.Size(317, 24);
            this.autoProcessToolStripMenuItem.Text = "Auto process (not implemented yet)";
            this.autoProcessToolStripMenuItem.Click += new System.EventHandler(this.autoProcessToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(62, 24);
            this.toolStripMenuItem1.Text = "&About";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Session|*.xml|All files|*.*";
            this.saveFileDialog1.Title = "Save session";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.Filter = "Session|*.xml|All files|*.*";
            this.openFileDialog2.Title = "Load session";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 490);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.byteMap1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "oxoSharp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.menuFixedRanges.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControls.FlashingTextBox txtFileName;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private UserControls.FlashingTextBox txtOutput;
        private UserControls.HexTextBox txtStart;
        private UserControls.HexTextBox txtEnd;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblSizeOrStep;
        private UserControls.HexTextBox txtSize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.RadioButton radioValue;
        private System.Windows.Forms.RadioButton radioNot;
        private System.Windows.Forms.RadioButton radioRandom;
        private oxoSharp.UserControls.HexTextBox txtValue;
        private System.Windows.Forms.RadioButton radioFixed;
        private System.Windows.Forms.RadioButton radioUnkFromStart;
        private System.Windows.Forms.RadioButton RadioUnkFromEnd;
        private System.Windows.Forms.Button btnHeader;
        private System.Windows.Forms.Button btnSections;
        private System.Windows.Forms.Button btnEof;
        private System.Windows.Forms.Button btnFullSiz;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Label label5;
        private UserControls.ByteMap2 byteMap1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnAutoSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblFillWith;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip menuFixedRanges;
        private System.Windows.Forms.ToolStripMenuItem itemAdd;
        private System.Windows.Forms.ToolStripMenuItem itemRemove;
        private System.Windows.Forms.ToolStripMenuItem itemClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem itemEdit;
        private System.Windows.Forms.ToolStripMenuItem itemSplit;
        private System.Windows.Forms.ToolStripMenuItem itemMerge;
        private System.Windows.Forms.ToolStripMenuItem itemCleanUp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblFill;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel lblMode;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lblPE;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sessionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoProcessToolStripMenuItem;
    }
}

