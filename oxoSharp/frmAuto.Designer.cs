namespace oxoSharp
{
    partial class frmAuto
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
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxSize = new oxoSharp.UserControls.HexTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAutoFixedHelp = new System.Windows.Forms.Button();
            this.chkSplitSignature = new System.Windows.Forms.CheckBox();
            this.radioFirstResult = new System.Windows.Forms.RadioButton();
            this.radioRandomResult = new System.Windows.Forms.RadioButton();
            this.radioLastResult = new System.Windows.Forms.RadioButton();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupSession = new System.Windows.Forms.GroupBox();
            this.chkUserDefinedRanges = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.hostedFlow = new System.Windows.Forms.Integration.ElementHost();
            this.autoprocessflow = new AutoProcessFlow.AutProcessFlow();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupOptions.SuspendLayout();
            this.groupSession.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.label4);
            this.groupOptions.Controls.Add(this.txtMaxSize);
            this.groupOptions.Controls.Add(this.label3);
            this.groupOptions.Controls.Add(this.btnAutoFixedHelp);
            this.groupOptions.Controls.Add(this.chkSplitSignature);
            this.groupOptions.Controls.Add(this.radioFirstResult);
            this.groupOptions.Controls.Add(this.radioRandomResult);
            this.groupOptions.Controls.Add(this.radioLastResult);
            this.groupOptions.Location = new System.Drawing.Point(20, 146);
            this.groupOptions.Margin = new System.Windows.Forms.Padding(4);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Padding = new System.Windows.Forms.Padding(4);
            this.groupOptions.Size = new System.Drawing.Size(241, 199);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Next range is :";
            // 
            // txtMaxSize
            // 
            this.txtMaxSize.FlashColor = System.Drawing.Color.Red;
            this.txtMaxSize.Location = new System.Drawing.Point(88, 158);
            this.txtMaxSize.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaxSize.Name = "txtMaxSize";
            this.txtMaxSize.Size = new System.Drawing.Size(117, 22);
            this.txtMaxSize.TabIndex = 7;
            this.txtMaxSize.Text = "50";
            this.txtMaxSize.TextChanged += new System.EventHandler(this.txtMaxSize_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 161);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max size :";
            // 
            // btnAutoFixedHelp
            // 
            this.btnAutoFixedHelp.Location = new System.Drawing.Point(203, 128);
            this.btnAutoFixedHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnAutoFixedHelp.Name = "btnAutoFixedHelp";
            this.btnAutoFixedHelp.Size = new System.Drawing.Size(25, 25);
            this.btnAutoFixedHelp.TabIndex = 5;
            this.btnAutoFixedHelp.Text = "?";
            this.btnAutoFixedHelp.UseVisualStyleBackColor = true;
            this.btnAutoFixedHelp.Click += new System.EventHandler(this.btnAutoFixedHelp_Click);
            // 
            // chkSplitSignature
            // 
            this.chkSplitSignature.AutoSize = true;
            this.chkSplitSignature.Location = new System.Drawing.Point(11, 129);
            this.chkSplitSignature.Margin = new System.Windows.Forms.Padding(4);
            this.chkSplitSignature.Name = "chkSplitSignature";
            this.chkSplitSignature.Size = new System.Drawing.Size(194, 21);
            this.chkSplitSignature.TabIndex = 4;
            this.chkSplitSignature.Text = "Auto generate fixed range";
            this.chkSplitSignature.UseVisualStyleBackColor = true;
            this.chkSplitSignature.CheckedChanged += new System.EventHandler(this.chkSplitSignature_CheckedChanged);
            // 
            // radioFirstResult
            // 
            this.radioFirstResult.AutoSize = true;
            this.radioFirstResult.Checked = true;
            this.radioFirstResult.Location = new System.Drawing.Point(91, 44);
            this.radioFirstResult.Margin = new System.Windows.Forms.Padding(4);
            this.radioFirstResult.Name = "radioFirstResult";
            this.radioFirstResult.Size = new System.Drawing.Size(95, 21);
            this.radioFirstResult.TabIndex = 3;
            this.radioFirstResult.TabStop = true;
            this.radioFirstResult.Text = "First result";
            this.radioFirstResult.UseVisualStyleBackColor = true;
            this.radioFirstResult.CheckedChanged += new System.EventHandler(this.radioNextResult_CheckedChanged);
            // 
            // radioRandomResult
            // 
            this.radioRandomResult.AutoSize = true;
            this.radioRandomResult.Location = new System.Drawing.Point(91, 101);
            this.radioRandomResult.Margin = new System.Windows.Forms.Padding(4);
            this.radioRandomResult.Name = "radioRandomResult";
            this.radioRandomResult.Size = new System.Drawing.Size(121, 21);
            this.radioRandomResult.TabIndex = 3;
            this.radioRandomResult.Text = "Random result";
            this.radioRandomResult.UseVisualStyleBackColor = true;
            this.radioRandomResult.CheckedChanged += new System.EventHandler(this.radioNextResult_CheckedChanged);
            // 
            // radioLastResult
            // 
            this.radioLastResult.AutoSize = true;
            this.radioLastResult.Location = new System.Drawing.Point(91, 73);
            this.radioLastResult.Margin = new System.Windows.Forms.Padding(4);
            this.radioLastResult.Name = "radioLastResult";
            this.radioLastResult.Size = new System.Drawing.Size(95, 21);
            this.radioLastResult.TabIndex = 3;
            this.radioLastResult.Text = "Last result";
            this.radioLastResult.UseVisualStyleBackColor = true;
            this.radioLastResult.CheckedChanged += new System.EventHandler(this.radioNextResult_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(85, 360);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(100, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupSession
            // 
            this.groupSession.Controls.Add(this.chkUserDefinedRanges);
            this.groupSession.Controls.Add(this.label1);
            this.groupSession.Controls.Add(this.label2);
            this.groupSession.Controls.Add(this.txtStart);
            this.groupSession.Controls.Add(this.txtEnd);
            this.groupSession.Location = new System.Drawing.Point(20, 16);
            this.groupSession.Margin = new System.Windows.Forms.Padding(4);
            this.groupSession.Name = "groupSession";
            this.groupSession.Padding = new System.Windows.Forms.Padding(4);
            this.groupSession.Size = new System.Drawing.Size(241, 123);
            this.groupSession.TabIndex = 0;
            this.groupSession.TabStop = false;
            this.groupSession.Text = "Session";
            // 
            // chkUserDefinedRanges
            // 
            this.chkUserDefinedRanges.AutoSize = true;
            this.chkUserDefinedRanges.Checked = true;
            this.chkUserDefinedRanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedRanges.Location = new System.Drawing.Point(8, 87);
            this.chkUserDefinedRanges.Margin = new System.Windows.Forms.Padding(4);
            this.chkUserDefinedRanges.Name = "chkUserDefinedRanges";
            this.chkUserDefinedRanges.Size = new System.Drawing.Size(219, 21);
            this.chkUserDefinedRanges.TabIndex = 5;
            this.chkUserDefinedRanges.Text = "Use user defined fixed ranges";
            this.chkUserDefinedRanges.UseVisualStyleBackColor = true;
            this.chkUserDefinedRanges.CheckedChanged += new System.EventHandler(this.chkUserDefinedRanges_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "End";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(91, 23);
            this.txtStart.Margin = new System.Windows.Forms.Padding(4);
            this.txtStart.Name = "txtStart";
            this.txtStart.ReadOnly = true;
            this.txtStart.Size = new System.Drawing.Size(116, 22);
            this.txtStart.TabIndex = 3;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(91, 55);
            this.txtEnd.Margin = new System.Windows.Forms.Padding(4);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ReadOnly = true;
            this.txtEnd.Size = new System.Drawing.Size(116, 22);
            this.txtEnd.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-9, -28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 384);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupSession);
            this.tabPage1.Controls.Add(this.groupOptions);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(550, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.hostedFlow);
            this.tabPage2.Controls.Add(this.progressBar1);
            this.tabPage2.Controls.Add(this.btnRestart);
            this.tabPage2.Controls.Add(this.btnResult);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(550, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // hostedFlow
            // 
            this.hostedFlow.Location = new System.Drawing.Point(17, 15);
            this.hostedFlow.Name = "hostedFlow";
            this.hostedFlow.Size = new System.Drawing.Size(511, 296);
            this.hostedFlow.TabIndex = 1;
            this.hostedFlow.Text = "elementHost1";
            this.hostedFlow.Child = this.autoprocessflow;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(17, 327);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(217, 11);
            this.progressBar1.TabIndex = 0;
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Location = new System.Drawing.Point(387, 317);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(141, 31);
            this.btnRestart.TabIndex = 3;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnResult
            // 
            this.btnResult.Enabled = false;
            this.btnResult.Location = new System.Drawing.Point(240, 317);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(141, 31);
            this.btnResult.TabIndex = 3;
            this.btnResult.Text = "Show results";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(85, 360);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 28);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // frmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 399);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto process";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAuto_FormClosing);
            this.Load += new System.EventHandler(this.frmAuto_Load);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupSession.ResumeLayout(false);
            this.groupSession.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox groupSession;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUserDefinedRanges;
        private System.Windows.Forms.RadioButton radioRandomResult;
        private System.Windows.Forms.RadioButton radioLastResult;
        private System.Windows.Forms.RadioButton radioFirstResult;
        private System.Windows.Forms.Label label4;
        private UserControls.HexTextBox txtMaxSize;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAutoFixedHelp;
        private System.Windows.Forms.CheckBox chkSplitSignature;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Integration.ElementHost hostedFlow;
        private AutoProcessFlow.AutProcessFlow autoprocessflow;
    }
}