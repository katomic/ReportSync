namespace ReportSync
{
    partial class ConvertTo2012
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
            this.ofdConvert = new System.Windows.Forms.OpenFileDialog();
            this.txtConvertFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadConvert = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtConvertProgress = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ofdConvert
            // 
            this.ofdConvert.DefaultExt = "rdl";
            this.ofdConvert.Filter = "Report Files|*.rdl";
            // 
            // txtConvertFileName
            // 
            this.txtConvertFileName.Location = new System.Drawing.Point(15, 37);
            this.txtConvertFileName.Name = "txtConvertFileName";
            this.txtConvertFileName.ReadOnly = true;
            this.txtConvertFileName.Size = new System.Drawing.Size(263, 20);
            this.txtConvertFileName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select the 2016 .rdl file to be converted";
            // 
            // btnLoadConvert
            // 
            this.btnLoadConvert.Location = new System.Drawing.Point(281, 36);
            this.btnLoadConvert.Name = "btnLoadConvert";
            this.btnLoadConvert.Size = new System.Drawing.Size(24, 23);
            this.btnLoadConvert.TabIndex = 2;
            this.btnLoadConvert.Text = "...";
            this.btnLoadConvert.UseVisualStyleBackColor = true;
            this.btnLoadConvert.Click += new System.EventHandler(this.btnLoadConvert_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.Location = new System.Drawing.Point(67, 65);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(191, 28);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtConvertProgress
            // 
            this.txtConvertProgress.Location = new System.Drawing.Point(12, 99);
            this.txtConvertProgress.Multiline = true;
            this.txtConvertProgress.Name = "txtConvertProgress";
            this.txtConvertProgress.ReadOnly = true;
            this.txtConvertProgress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtConvertProgress.Size = new System.Drawing.Size(296, 208);
            this.txtConvertProgress.TabIndex = 7;
            // 
            // ConvertTo2012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 319);
            this.Controls.Add(this.txtConvertProgress);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.btnLoadConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConvertFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertTo2012";
            this.Text = "Convert 2016 rdl to 2012";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdConvert;
        private System.Windows.Forms.TextBox txtConvertFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadConvert;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtConvertProgress;
    }
}