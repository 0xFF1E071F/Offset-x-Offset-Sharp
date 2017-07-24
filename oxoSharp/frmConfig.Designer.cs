namespace oxoSharp
{
    partial class frmConfig
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
            this.chkAutoDetectPE = new System.Windows.Forms.CheckBox();
            this.chkReinitSessionOnLoad = new System.Windows.Forms.CheckBox();
            this.txtDivider = new oxoSharp.UserControls.HexTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.chkAutoReload = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtAV = new UserControls.FlashingTextBox();
            this.txtCmdln = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkAutoDetectPE
            // 
            this.chkAutoDetectPE.AutoSize = true;
            this.chkAutoDetectPE.Location = new System.Drawing.Point(6, 19);
            this.chkAutoDetectPE.Name = "chkAutoDetectPE";
            this.chkAutoDetectPE.Size = new System.Drawing.Size(98, 17);
            this.chkAutoDetectPE.TabIndex = 0;
            this.chkAutoDetectPE.Text = "Auto detect PE";
            this.chkAutoDetectPE.UseVisualStyleBackColor = true;
            // 
            // chkReinitSessionOnLoad
            // 
            this.chkReinitSessionOnLoad.AutoSize = true;
            this.chkReinitSessionOnLoad.Location = new System.Drawing.Point(6, 19);
            this.chkReinitSessionOnLoad.Name = "chkReinitSessionOnLoad";
            this.chkReinitSessionOnLoad.Size = new System.Drawing.Size(145, 17);
            this.chkReinitSessionOnLoad.TabIndex = 0;
            this.chkReinitSessionOnLoad.Text = "Reinit session on file load";
            this.chkReinitSessionOnLoad.UseVisualStyleBackColor = true;
            // 
            // txtDivider
            // 
            this.txtDivider.FlashColor = System.Drawing.Color.Red;
            this.txtDivider.Location = new System.Drawing.Point(96, 19);
            this.txtDivider.Name = "txtDivider";
            this.txtDivider.Size = new System.Drawing.Size(47, 20);
            this.txtDivider.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auto size divider";
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(6, 42);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(146, 17);
            this.chkAutoSave.TabIndex = 0;
            this.chkAutoSave.Text = "Auto save session on exit";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            // 
            // chkAutoReload
            // 
            this.chkAutoReload.AutoSize = true;
            this.chkAutoReload.Location = new System.Drawing.Point(6, 65);
            this.chkAutoReload.Name = "chkAutoReload";
            this.chkAutoReload.Size = new System.Drawing.Size(167, 17);
            this.chkAutoReload.TabIndex = 0;
            this.chkAutoReload.Text = "Reload last session on startup";
            this.chkAutoReload.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(41, 340);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 340);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkReinitSessionOnLoad);
            this.groupBox1.Controls.Add(this.chkAutoSave);
            this.groupBox1.Controls.Add(this.chkAutoReload);
            this.groupBox1.Location = new System.Drawing.Point(12, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 95);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Session";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutoDetectPE);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 47);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PE detection";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtDivider);
            this.groupBox3.Location = new System.Drawing.Point(12, 165);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 56);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Variable range";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtCmdln);
            this.groupBox4.Controls.Add(this.txtAV);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(12, 228);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(201, 106);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "AntiVirus";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 38);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Command line";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Executable";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Exe file|*.exe|All files|*.*";
            this.openFileDialog1.Title = "Select AntiVirus exe file";
            // 
            // txtAV
            // 
            this.txtAV.Location = new System.Drawing.Point(6, 39);
            this.txtAV.Name = "txtAV";
            this.txtAV.Size = new System.Drawing.Size(158, 20);
            this.txtAV.TabIndex = 4;
            // 
            // txtCmdln
            // 
            this.txtCmdln.Location = new System.Drawing.Point(6, 78);
            this.txtCmdln.Name = "txtCmdln";
            this.txtCmdln.Size = new System.Drawing.Size(189, 20);
            this.txtCmdln.TabIndex = 5;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 373);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmConfig_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkAutoDetectPE;
        private System.Windows.Forms.CheckBox chkReinitSessionOnLoad;
        private UserControls.HexTextBox txtDivider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.CheckBox chkAutoReload;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtCmdln;
        private UserControls.FlashingTextBox txtAV;
    }
}