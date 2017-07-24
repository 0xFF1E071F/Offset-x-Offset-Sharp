namespace oxoSharp
{
    partial class frmAction
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
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnSecond = new System.Windows.Forms.Button();
            this.btnThird = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(12, 12);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(128, 34);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Tag = 0;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btns_Click);
            // 
            // btnSecond
            // 
            this.btnSecond.Location = new System.Drawing.Point(12, 52);
            this.btnSecond.Name = "btnSecond";
            this.btnSecond.Size = new System.Drawing.Size(128, 34);
            this.btnSecond.TabIndex = 0;
            this.btnSecond.Tag = 1;
            this.btnSecond.UseVisualStyleBackColor = true;
            this.btnSecond.Click += new System.EventHandler(this.btns_Click);
            // 
            // btnThird
            // 
            this.btnThird.Location = new System.Drawing.Point(12, 92);
            this.btnThird.Name = "btnThird";
            this.btnThird.Size = new System.Drawing.Size(128, 34);
            this.btnThird.TabIndex = 0;
            this.btnThird.Tag = 2;
            this.btnThird.UseVisualStyleBackColor = true;
            this.btnThird.Click += new System.EventHandler(this.btns_Click);
            // 
            // frmAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(152, 140);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.btnSecond);
            this.Controls.Add(this.btnThird);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAction";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Action";
            this.Load += new System.EventHandler(this.frmAction_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmRangeAction_KeyPress);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnSecond;
        private System.Windows.Forms.Button btnThird;
    }
}