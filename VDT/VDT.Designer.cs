namespace VDT
{
    partial class VDT
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
            this.txtOk = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFail = new System.Windows.Forms.RichTextBox();
            this.txtLinkFile = new System.Windows.Forms.TextBox();
            this.SelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOk
            // 
            this.txtOk.Location = new System.Drawing.Point(16, 107);
            this.txtOk.Name = "txtOk";
            this.txtOk.Size = new System.Drawing.Size(339, 284);
            this.txtOk.TabIndex = 1;
            this.txtOk.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Thêm số vé";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFail
            // 
            this.txtFail.Location = new System.Drawing.Point(362, 107);
            this.txtFail.Name = "txtFail";
            this.txtFail.Size = new System.Drawing.Size(236, 284);
            this.txtFail.TabIndex = 4;
            this.txtFail.Text = "";
            // 
            // txtLinkFile
            // 
            this.txtLinkFile.Enabled = false;
            this.txtLinkFile.Location = new System.Drawing.Point(12, 57);
            this.txtLinkFile.Multiline = true;
            this.txtLinkFile.Name = "txtLinkFile";
            this.txtLinkFile.Size = new System.Drawing.Size(205, 33);
            this.txtLinkFile.TabIndex = 1;
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(223, 57);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(116, 33);
            this.SelectFile.TabIndex = 0;
            this.SelectFile.Text = "Chọn File";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(439, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Xin chào: ";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblFullName.Location = new System.Drawing.Point(490, 13);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(0, 13);
            this.lblFullName.TabIndex = 6;
            // 
            // VDT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 389);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLinkFile);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.txtFail);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtOk);
            this.Name = "VDT";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Thêm số vé";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox txtFail;
        private System.Windows.Forms.TextBox txtLinkFile;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblFullName;
    }
}

