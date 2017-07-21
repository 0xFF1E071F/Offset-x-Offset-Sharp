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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
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
            this.groupOptions.Location = new System.Drawing.Point(15, 119);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(181, 162);
            this.groupOptions.TabIndex = 0;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Next range is :";
            // 
            // txtMaxSize
            // 
            this.txtMaxSize.FlashColor = System.Drawing.Color.Red;
            this.txtMaxSize.Location = new System.Drawing.Point(66, 128);
            this.txtMaxSize.Name = "txtMaxSize";
            this.txtMaxSize.Size = new System.Drawing.Size(89, 20);
            this.txtMaxSize.TabIndex = 7;
            this.txtMaxSize.Text = "50";
            this.txtMaxSize.TextChanged += new System.EventHandler(this.txtMaxSize_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Max size :";
            // 
            // btnAutoFixedHelp
            // 
            this.btnAutoFixedHelp.Location = new System.Drawing.Point(152, 104);
            this.btnAutoFixedHelp.Name = "btnAutoFixedHelp";
            this.btnAutoFixedHelp.Size = new System.Drawing.Size(19, 20);
            this.btnAutoFixedHelp.TabIndex = 5;
            this.btnAutoFixedHelp.Text = "?";
            this.btnAutoFixedHelp.UseVisualStyleBackColor = true;
            this.btnAutoFixedHelp.Click += new System.EventHandler(this.btnAutoFixedHelp_Click);
            // 
            // chkSplitSignature
            // 
            this.chkSplitSignature.AutoSize = true;
            this.chkSplitSignature.Location = new System.Drawing.Point(8, 105);
            this.chkSplitSignature.Name = "chkSplitSignature";
            this.chkSplitSignature.Size = new System.Drawing.Size(148, 17);
            this.chkSplitSignature.TabIndex = 4;
            this.chkSplitSignature.Text = "Auto generate fixed range";
            this.chkSplitSignature.UseVisualStyleBackColor = true;
            this.chkSplitSignature.CheckedChanged += new System.EventHandler(this.chkSplitSignature_CheckedChanged);
            // 
            // radioFirstResult
            // 
            this.radioFirstResult.AutoSize = true;
            this.radioFirstResult.Checked = true;
            this.radioFirstResult.Location = new System.Drawing.Point(68, 36);
            this.radioFirstResult.Name = "radioFirstResult";
            this.radioFirstResult.Size = new System.Drawing.Size(72, 17);
            this.radioFirstResult.TabIndex = 3;
            this.radioFirstResult.TabStop = true;
            this.radioFirstResult.Text = "First result";
            this.radioFirstResult.UseVisualStyleBackColor = true;
            this.radioFirstResult.CheckedChanged += new System.EventHandler(this.radioNextResult_CheckedChanged);
            // 
            // radioRandomResult
            // 
            this.radioRandomResult.AutoSize = true;
            this.radioRandomResult.Location = new System.Drawing.Point(68, 82);
            this.radioRandomResult.Name = "radioRandomResult";
            this.radioRandomResult.Size = new System.Drawing.Size(93, 17);
            this.radioRandomResult.TabIndex = 3;
            this.radioRandomResult.Text = "Random result";
            this.radioRandomResult.UseVisualStyleBackColor = true;
            this.radioRandomResult.CheckedChanged += new System.EventHandler(this.radioNextResult_CheckedChanged);
            // 
            // radioLastResult
            // 
            this.radioLastResult.AutoSize = true;
            this.radioLastResult.Location = new System.Drawing.Point(68, 59);
            this.radioLastResult.Name = "radioLastResult";
            this.radioLastResult.Size = new System.Drawing.Size(73, 17);
            this.radioLastResult.TabIndex = 3;
            this.radioLastResult.Text = "Last result";
            this.radioLastResult.UseVisualStyleBackColor = true;
            this.radioLastResult.CheckedChanged += new System.EventHandler(this.radioNextResult_CheckedChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(61, 291);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
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
            this.groupSession.Location = new System.Drawing.Point(15, 13);
            this.groupSession.Name = "groupSession";
            this.groupSession.Size = new System.Drawing.Size(181, 100);
            this.groupSession.TabIndex = 0;
            this.groupSession.TabStop = false;
            this.groupSession.Text = "Session";
            // 
            // chkUserDefinedRanges
            // 
            this.chkUserDefinedRanges.AutoSize = true;
            this.chkUserDefinedRanges.Checked = true;
            this.chkUserDefinedRanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUserDefinedRanges.Location = new System.Drawing.Point(6, 71);
            this.chkUserDefinedRanges.Name = "chkUserDefinedRanges";
            this.chkUserDefinedRanges.Size = new System.Drawing.Size(166, 17);
            this.chkUserDefinedRanges.TabIndex = 5;
            this.chkUserDefinedRanges.Text = "Use user defined fixed ranges";
            this.chkUserDefinedRanges.UseVisualStyleBackColor = true;
            this.chkUserDefinedRanges.CheckedChanged += new System.EventHandler(this.chkUserDefinedRanges_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(68, 19);
            this.txtStart.Name = "txtStart";
            this.txtStart.ReadOnly = true;
            this.txtStart.Size = new System.Drawing.Size(88, 20);
            this.txtStart.TabIndex = 3;
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(68, 45);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.ReadOnly = true;
            this.txtEnd.Size = new System.Drawing.Size(88, 20);
            this.txtEnd.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-7, -23);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(218, 312);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupSession);
            this.tabPage1.Controls.Add(this.groupOptions);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(210, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(210, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(15, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(182, 100);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Progress";
            // 
            // frmAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 324);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuto";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Auto process";
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
        private System.Windows.Forms.GroupBox groupBox3;
    }
}